using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemSp.Core.Entities;
using SystemSp.Core.Interfaces;
using SystemSp.DTOS.EntitisFormsApp;
using SystemSp.DTOS.EntitisIndexApp;
using SystemSp.DTOS.EntitisProjectsApp;
using SystemSp.DTOS.EntitisViewApp;
using SystemSp.Infrastructure.Data;

namespace SystemSp.Infrastructure.Repositories
{
    public abstract class BusinessImplementation
    {
        private readonly SystemSpContext _Context;
        private readonly ISystemSpAzureBlob _azureBlob;
        public BusinessImplementation(SystemSpContext context, ISystemSpAzureBlob azureBlob)
        {
            _Context = context;
            _azureBlob = azureBlob;
        }
        private async Task<Tuple<bool, bool, bool>> _userExist(string identification, string email)
        {
            bool exist = true;
            bool mailEx = false;
            bool idExist = false;
            var usu = await _Context.Usuario.Where((x)
                => x.DireccionEmail == email || x.NumeroDocumento == identification)
                .FirstOrDefaultAsync();
            if (usu == null)
                exist = false;
            else
            {
                if (usu.DireccionEmail == email)
                    mailEx = true;
                if (usu.NumeroDocumento == identification)
                    idExist = true;
                exist = true;
            }
            return new Tuple<bool, bool, bool>(exist, mailEx, idExist);
        }
        private ProjectCard _getCard(Proyecto project)
        {
            var result = new ProjectCard();
            try
            {
                string imageUser = string.Empty;
                Usuario user = _Context.Usuario.FirstOrDefault(
                             x => x.IdUsuario == project.IdUsuario);
                if (user.ImagenUsuario != null)
                {
                    imageUser = Encoding.UTF8.GetString(
                    user.ImagenUsuario, 0, user.ImagenUsuario.Length);
                }
                else
                    imageUser = $"{user.Nombre[0]} {user.Apellido[0]}";
                result.IdProyecto = project.IdProyecto;
                result.Categoria = project.Categoria;
                result.NombreUsuario = $"{user.Nombre} {user.Apellido}";
                result.NumeroCelular = user.NumeroCelular;
                result.DireccionEmail = user.DireccionEmail;
                result.TituloProyecto = project.NombreProyecto;
                result.Descripcion = project.DescripcionProyecto;
                result.ImagenUsuario = imageUser;
            }
            catch (Exception ex)
            {
                result.Descripcion = "Error";
            }
            return result;
        }
        private async Task<bool> _insertProject(FormProjectApp appProject)
        {
            using (_Context)
            {
                bool result = false;
                try
                {
                    //remueve los espacios de la categoria
                    string categoria = _getCategory(appProject.Category);
                    string _projectName = string.Concat(appProject.NameProject.Where(c => !char.IsWhiteSpace(c)));

                    var datePost = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    var dateProject = DateTime.Now;
                    DateTime.TryParse(appProject.ProjectDate, out dateProject);

                    var images = new List<ImagenesProyecto>();
                    var team = new List<IntegrantesProyecto>();
                    var documentos = new List<DocumentosProyecto>();

                    var imagesData = new Dictionary<string, string>();
                    var fileData = new Dictionary<string, string>();

                    Usuario user = await _Context.Usuario.FirstOrDefaultAsync(
                        x => x.IdUsuario == appProject.UserId);

                    //Nombre del contenedor por proyecto
                    string containerImage = $"{_projectName.ToLower()}-images";
                    string containerArchivos = $"{_projectName.ToLower()}-archivos";

                    //Se agrega la lista de imagenes que se guarda en la base de datos
                    int numImg = 1;
                    appProject.ImagesData.ForEach(img =>
                    {
                        string nombreImagen = $"{img.FileType.Replace("/", $"0{numImg}.")}";
                        images.Add(new ImagenesProyecto()
                        {
                            NombreImagen = nombreImagen,
                            ImagenOriginal = img.FileName,
                            TipoImagen = img.FileType,
                            NombreContenedor = containerImage
                        });
                        imagesData.Add(nombreImagen, img.FileStreamContent);
                        numImg++;
                    });
                   

                    //Se agrega la lista de archivos que se guarda en la base de datos
                    int numFile = 1;
                    appProject.FilesData.ForEach(file =>
                    {
                        string nombreDocumento = $"{file.FileType.Replace("/", $"0{numFile}.")}";
                        documentos.Add(new DocumentosProyecto() 
                        {
                            NombreDocumento = nombreDocumento,
                            TipoDocumento = file.FileType,
                            NombreContenedor = containerArchivos
                        });
                        fileData.Add(nombreDocumento, file.FileStreamContent);
                        numFile++;
                    });

                    //guardar tecnologias usadas;
                    var tetch = getTech(appProject.TechBackEnd, appProject.TechFrontEnd, appProject.TechDataBase);

                    //Insertar proyecto de formación
                    var formativeProject = new Proyecto()
                    {
                        IdUsuario = user.IdUsuario,
                        IdVinculacion = 0,
                        NombreProyecto = _projectName,
                        Categoria = categoria,
                        DescripcionProyecto = appProject.ProjectDescription,
                        FechaFormacion = dateProject,
                        FechaPublicacion = datePost,
                        FechaActualizacion = null,
                        FechaEliminado = null,
                        Departamento = appProject.Departament,
                        Ciudad = appProject.TrainingCity,
                        Estado = "Activo",
                        NumeroDescargas = 0,
                        NumeroVisitas = 0,
                        IntegrantesProyecto = team,
                        NombreSena = appProject.SenaName,
                        ImagenesProyecto = images,
                        DocumentosProyecto = documentos,
                        TecnologiasUtilizadas = tetch
                    };
                    if (user.TipoUsuario == 1)
                        await _updateNumProjectAdmin(user.IdUsuario);
                    else if (user.TipoUsuario == 2)
                        await _updateNumProjecApprentice(user.IdUsuario);

                    if (appProject.ApprenticesData.Count > 0)
                    {
                        appProject.ApprenticesData.ForEach((stu) =>
                        {
                            team.Add(new IntegrantesProyecto()
                            {
                                Nombre = stu.FirstName,
                                Apellido = stu.LastName,
                                Telefono = stu.Telephone,
                                Correo = stu.Email,
                                IdUsuarioCreador = user.IdUsuario,
                                Estado = "Activo",
                                FechaActualizacion = datePost
                            });
                        });
                        formativeProject.IntegrantesProyecto = team;
                    }
                    var credor = new UsuarioCreadorProyecto()
                    {
                        FechaCreacion = datePost,
                        IdCreador = user.IdUsuario,
                        NombreUsuario = $"{user.Nombre} {user.Apellido}",
                        Proyecto = new List<Proyecto>() { formativeProject },
                        TipoUsuario = user.TipoUsuario
                    };
                    _Context.UsuarioCreadorProyecto.Add(credor);
                    int resultSave = await _Context.SaveChangesAsync();
                    if (resultSave > 0)
                    {
                        //Insertar Imagen azure storage 
                        await _azureBlob.SaveBlobImage(imagesData, containerImage, false);
                        //Insertar archivos azure storage 
                        await _azureBlob.SaveBlobImage(fileData, containerArchivos, true);
                    }
                    result = true;
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }
        private List<TecnologiasUtilizadas> getTech(string back, string front, string db) 
        {
            return new List<TecnologiasUtilizadas>()
            {
                new TecnologiasUtilizadas()
                {
                    TecnologiasFront = front,
                    TecnologiasBack = back,
                    TecnologiasDb = db
                }
            };
        }
        private async Task _updateNumProjecApprentice(int idUser)
        {
            int idApprentice = _Context.UsuarioAprendiz.FirstOrDefault(
                            x => x.IdUsuario == idUser).IdAprendiz;

            UsuarioAprendiz aprendice = await _Context.UsuarioAprendiz.FirstOrDefaultAsync((x) =>
                    x.IdAprendiz == idApprentice);
            if (aprendice.CantidadProyectos == 0)
                aprendice.CantidadProyectos = 1;
            else
                aprendice.CantidadProyectos = aprendice.CantidadProyectos + 1;
            _Context.SaveChanges();
        }
        private async Task _updateNumProjectAdmin(int idUser)
        {
            int idAdmin = _Context.UsuarioAdministrador.FirstOrDefault(
                            x => x.IdUsuario == idUser).IdAdmin;
            UsuarioAdministrador admin = await _Context.UsuarioAdministrador.FirstOrDefaultAsync(
                (x) => x.IdAdmin == idAdmin);
            if (admin.ProyectosPublicados == 0)
                admin.ProyectosPublicados = 1;
            else
                admin.ProyectosPublicados = admin.ProyectosPublicados + 1;
            _Context.SaveChanges();
        }
        public async Task<bool> InsertFormativeProject(FormProjectApp appProject)
            => await _insertProject(appProject);
        public async Task<List<ReportApp>> GetReports() 
        {
            using (_Context) 
            {
                var salida = new List<ReportApp>();
                List<Proyecto> project = await _Context.Proyecto.Take(10).ToListAsync();
                project.ForEach(x => 
                {
                    salida.Add(new ReportApp() 
                    {
                        Categoria = x.Categoria,
                        Ciudad = x.Ciudad,
                        FechaPublicacion = x.FechaPublicacion,
                        NombreProyecto = x.NombreProyecto
                    });
                });
                return salida;
            }

        }
        public async Task<List<InformationDocuments>> GetDocumentUri(int idProject) 
        {
            var documentsResult = new List<InformationDocuments>();
            try
            {
                var documents = await _Context.DocumentosProyecto.Where(x => x.IdProyecto == idProject).ToListAsync();

                if (documents.Any()) 
                {
                    string container = await _Context.DocumentosProyecto.Where(x=> x.IdProyecto == idProject)
                        .Select(x=> x.NombreContenedor).FirstOrDefaultAsync();
                    documents.ForEach(x=> 
                    {
                        documentsResult.Add(new InformationDocuments 
                        {
                           FileName = x.NombreDocumento,
                           FileType = x.TipoDocumento
                        });
                    
                    });
                    return _azureBlob.GetDocumentsContainer(documentsResult, container);
                }
            }
            catch (Exception ex)
            {
                string ms = ex.Message;
            }
            return documentsResult;
        }
        public ProjectCard GetCard(Proyecto project)
            => _getCard(project);
        public async Task<UserInformation> InsertUserRol(FormRegister formLogin)
        {
            using (_Context)
            {
                var usuInfo = new UserInformation()
                {
                    MessageStates = new UserMessageStates()
                };
                try
                {
                    Tuple<bool, bool, bool> usuarioExiste = await _userExist(formLogin.IdentificationNumber, formLogin.Email);
                    if (usuarioExiste.Item1 == false)
                    {
                        var user = new Usuario()
                        {
                            Nombre = formLogin.NameUser,
                            Apellido = formLogin.LastNameUser,
                            Contrasenia = formLogin.Password,
                            DireccionEmail = formLogin.Email,
                            FechaCreacion = DateTime.Now,
                            NumeroCelular = formLogin.Telephone,
                            NumeroDocumento = formLogin.IdentificationNumber,
                            TipoDocumento = formLogin.IdentificacionType,
                            TipoUsuario = formLogin.UserType
                        };
                        if (formLogin.UserType == 2)
                        {
                            user.UsuarioAprendiz = new List<UsuarioAprendiz>()
                            {
                                new UsuarioAprendiz()
                                {
                                    CantidadProyectos = 0,
                                }
                            };
                        }
                        else if (formLogin.UserType == 3)
                        {
                            user.UsuarioEmpresa = new List<UsuarioEmpresa>()
                            {
                                new UsuarioEmpresa()
                                {
                                    CantidadSolicitudes = 0,
                                    Ciudad = formLogin.City,
                                    Direccion = formLogin.CompanyAddress,
                                    NombreEmpresa = formLogin.CompanyName
                                }
                            };
                        }
                        await _Context.Usuario.AddAsync(user);
                        _Context.SaveChanges();
                        var usuResult = await _Context.Usuario.FirstOrDefaultAsync(_item
                            => _item.NumeroDocumento == formLogin.IdentificationNumber);
                        if (usuResult != null)
                        {
                            usuInfo = _getInfoUser(usuResult);
                            usuInfo.MessageStates = new UserMessageStates()
                            {
                                UserCreateSuccessfull = true
                            };
                        }
                        else
                            usuInfo.MessageStates.UserCreateSuccessfull = false;
                    }
                    else
                    {
                        usuInfo.MessageStates.UserExist = true;
                        if (usuarioExiste.Item2)
                            usuInfo.MessageStates.UserEmailExist = true;
                        if (usuarioExiste.Item3)
                            usuInfo.MessageStates.UserIdentificationExist = true;
                    }
                }
                catch
                {
                    usuInfo.MessageStates.UserCreateSuccessfull = false;
                }
                return usuInfo;
            }
        }
        public async Task<UserInformation> UserResponse(FormLogin login)
        {
            var usuInfo = new UserInformation()
            {
                MessageStates = new UserMessageStates()
            };
            try
            {
                Usuario user = await _Context.Usuario.FirstOrDefaultAsync(
                    x => x.DireccionEmail == login.EmailLogin && x.Contrasenia == login.PasswordLogin);
                if (user != null)
                {
                    usuInfo = _getInfoUser(user);
                    usuInfo.MessageStates = new UserMessageStates()
                    {
                        UserExist = true
                    };
                }
                else
                    usuInfo.MessageStates.UserExist = false;
            }
            catch (Exception ex)
            {
                usuInfo.MessageStates.UserExist = false;
                string message = ex.Message;
            }
            return usuInfo;
        }
        public async Task<IEnumerable<UserInformation>> GetUsers() 
        {
            using (_Context) 
            {
                var listUsers = new List<UserInformation>();
                try
                {
                    var users = await _Context.Usuario.Take(10).ToListAsync();
                    users.ForEach(itemUser=> 
                    {
                        var usu = _getInfoUser(itemUser);
                        listUsers.Add(usu);
                    });
                }
                catch
                {
                    listUsers.Add(new UserInformation()
                    {
                        MessageStates = new UserMessageStates() 
                        {
                            UserEmailExist = false,
                            UserCreateSuccessfull =false,
                            UserExist = false,
                            UserIdentificationExist = false
                        }
                    }) ;
                }
                return listUsers;
            }
        }
        private UserInformation _getInfoUser(Usuario usuResult)
        {
            var saldia = new UserInformation()
            {
                UserId = usuResult.IdUsuario,
                UserImage = $"{usuResult.Nombre[0]} {usuResult.Apellido[0]}",
                UserName = $"{usuResult.Nombre} {usuResult.Apellido}",
                UserPassword = usuResult.Contrasenia,
                UserTelephone = usuResult.NumeroCelular,
                UserEmail = usuResult.DireccionEmail,
                UserType = usuResult.TipoUsuario
            };
            return saldia;
        }
        public async Task<bool> ChangeStatusPerson(UpdateDataProject updateData)
        {
            using (_Context)
            {
                bool result = false;
                try
                {
                    var apprentice = await _Context.IntegrantesProyecto.FirstOrDefaultAsync(
                        x => x.IdPersona == updateData.IdApprentice && x.IdUsuarioCreador == updateData.IdUser
                        && x.IdProyecto == updateData.IdProject);
                    if (apprentice != null)
                    {
                        _Context.IntegrantesProyecto.Remove(apprentice);
                        _Context.SaveChanges();
                        result = true;
                    }
                }
                catch(Exception ex) 
                {
                    string ms = ex.Message;
                }
                return result;
            };
        }
        public async Task<bool> ChangeInformationPerson(UpdateDataProject updateData)
        {
            using (_Context)
            {
                bool result = false;
                try
                {
                    var apprentice = await _Context.IntegrantesProyecto.FirstOrDefaultAsync(
                        x => x.IdPersona == updateData.IdApprentice && x.IdUsuarioCreador == updateData.IdUser
                        && x.IdProyecto == updateData.IdProject);
                    if (apprentice != null)
                    {
                        apprentice.Estado = updateData.Estado;
                        apprentice.FechaActualizacion = DateTime.Now;
                        apprentice.Nombre = updateData.Aprentice.Nombre;
                        apprentice.Apellido = updateData.Aprentice.Apellido;
                        apprentice.Telefono = updateData.Aprentice.Telefono;
                        apprentice.Correo = updateData.Aprentice.Email;
                        _Context.SaveChanges();
                        result = true;
                    }
                    else
                    {
                        var apprenticeVal = new IntegrantesProyecto()
                        {
                            IdProyecto = updateData.IdProject,
                            IdUsuarioCreador = updateData.IdUser,
                            Apellido = updateData.Aprentice.Apellido,
                            Nombre = updateData.Aprentice.Nombre,
                            Correo = updateData.Aprentice.Email,
                            Telefono = updateData.Aprentice.Telefono,
                            Estado = updateData.Estado,
                            FechaActualizacion = DateTime.Now,
                        };
                        _Context.IntegrantesProyecto.Add(apprenticeVal);
                        _Context.SaveChanges();
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    string ms = ex.Message;
                }
                return result;
            };
        }
        public async Task<bool> ChangeProjectState(UpdateDataProject updateData)
        {
            using (_Context)
            {
                try
                {
                    var project = await _Context.Proyecto.FirstOrDefaultAsync(
                        (x) => x.IdProyecto == updateData.IdProject && x.IdUsuario == updateData.IdUser
                        && x.Estado != "Eliminado");
                    if (project != null)
                    {
                        if (updateData.Estado == "Eliminado")
                            project.FechaEliminado = DateTime.Now;
                        else if (updateData.Estado == "Actualizado")
                            project.FechaActualizacion = DateTime.Now;
                        project.Estado = updateData.Estado;
                        _Context.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception ex) 
                {
                    string ms = ex.Message;
                    return false;
                }
            }
        }
        public async Task<List<string>> GetImagesAzureBlob(int IdProject)
        {
            List<ImagenesProyecto> images = await _Context.ImagenesProyecto
                .Where(x => x.IdProyecto == IdProject).ToListAsync();
            var dicImages = new Dictionary<string, string>();

            images.ForEach(x => dicImages.Add(x.NombreImagen, x.TipoImagen));

            string container = await _Context.ImagenesProyecto
                .Where(x => x.IdProyecto == IdProject)
                .Select(x => x.NombreContenedor).FirstOrDefaultAsync();

            List<string> result = await _azureBlob.GetImagesContainer(dicImages, container);
            return result;
        }
        public async Task<List<string>> GetPopularCategory()
        {
            var lstSalida = new List<string>();
            try
            {
                using (_Context)
                {
                    //Ejecutando Procedimiento almacenado
                    lstSalida = _Context.Proyecto.FromSqlRaw("spObtenerCategoriasPopulares")
                        .Select(x => x.Categoria).ToList();
                }
            }
            catch (Exception ex)
            {
                lstSalida[0] = "NOK";
            }
            return lstSalida;
        }
        public async Task<bool> ValidaEmailUser(string email)
        {
            using (_Context) 
            {
                try
                {
                    Usuario usu = await _Context.Usuario.Where(x=> x.DireccionEmail == email)
                        .FirstOrDefaultAsync();
                    if (usu != null)
                        return true;
                    else return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public async Task<List<ProjectDetails>> GetProjectsUser(int IdUser)
        {
            using (_Context)
            {
                var result = new List<ProjectDetails>();
                try
                {
                    var projectSalida = await _Context.Proyecto.Where(
                        (x) => x.IdUsuario == IdUser && x.Estado != "Eliminado").ToListAsync();
                    if (projectSalida != null && projectSalida.Count > 0)
                    {
                        //Llenando los detalles del proyecto por cada resultado de la Consulta
                        foreach (var iVal in projectSalida)
                        {
                            var project = new ProjectDetails()
                            {
                                ImagenesProyecto = new List<string>(),
                                Aprendices = new List<ApprenticeData>()
                            };
                            List<IntegrantesProyecto> integrantes = _Context.IntegrantesProyecto
                                .Where(x => x.IdUsuarioCreador == iVal.IdUsuario && x.Estado == "Activo").ToList();

                            project.Descripcion = iVal.DescripcionProyecto;
                            project.Categoria = iVal.Categoria;
                            project.IdProyecto = iVal.IdProyecto;
                            project.NombreProyecto = iVal.NombreProyecto;
                            project.NumeroDescargas = iVal.NumeroDescargas.ToString();
                            project.NumeroVistas = iVal.NumeroVisitas.ToString();

                            //Obtener Imagenes del proyecto desde azure storege
                            project.ImagenesProyecto = await GetImagesAzureBlob(iVal.IdProyecto);

                            integrantes.ForEach(x =>
                            {
                                project.Aprendices.Add(new ApprenticeData()
                                {
                                    Email = x.Correo,
                                    FirstName = x.Nombre,
                                    LastName = x.Apellido,
                                    Telephone = x.Telefono,
                                    IdApprentice = x.IdPersona,
                                    Status = x.Estado
                                });
                            });
                            project.Process = true;
                            result.Add(project);
                        }
                    }
                }
                catch (Exception) { }
                return result;
            }
        }
        public async Task<FeaturedProjects> GetPopularProjects()
        {
            using (_Context)
            {
                var popularProject = new FeaturedProjects();
                try
                {
                    List<Proyecto> project = await _Context.Proyecto.Take(10)
                        .Where((x) => x.Estado != "Eliminado").ToListAsync();
                    var cards = new List<ProjectCard>();
                    project.ForEach(item =>
                    {
                        var card = GetCard(item);
                        if (card.Descripcion != "Error")
                            cards.Add(card);
                    });
                    popularProject.ProjectCardList = cards;
                    return popularProject;
                }
                catch (Exception ex)
                {
                    string mens = ex.Message;
                    return popularProject;
                }
            }
        }
        public async Task<ProjectInformation> GetFormativeProject(int idProject) 
        {
            using (_Context)
            {
                var project = new ProjectInformation()
                {
                    ProjectCardInfo = new ProjectCard(),
                    ImagesProject = new List<string>()
                };
                try
                {
                    var formativeProject = await _Context.Proyecto
                        .FirstOrDefaultAsync((x) => x.IdProyecto == idProject && x.Estado != "Eliminado");
                    if (formativeProject != null)
                    {
                        ProjectCard card = GetCard(formativeProject);
                        project.ImagesProject = await GetImagesAzureBlob(formativeProject.IdProyecto);
                        project.ProjectCardInfo = card;
                        project.TechnologiesUsed = _getListTechnology(formativeProject.IdProyecto);
                    }
                }
                catch { }
                return project;
            }
        }
        public async Task<IEnumerable<ProjectInformation>> GetProjects()
        {
            var ltsProject = new List<ProjectInformation>();
            try
            {
                var formativeProject = await _Context.Proyecto.Take(5).ToListAsync();
                if (formativeProject.Any())
                {
                    formativeProject.ForEach(projItem =>
                    {
                        var project = new ProjectInformation();
                        ProjectCard card = GetCard(projItem);
                        project.ProjectCardInfo = card;
                        project.TechnologiesUsed = _getListTechnology(projItem.IdProyecto);

                        ltsProject.Add(project);
                    });
                }
            }
            catch (Exception ex)
            {
                ltsProject.Add(new ProjectInformation
                {
                    Status = ex.Message
                });
            }
            return ltsProject;
        }

        public async Task<IEnumerable<RequestData>> GetRequests()
        {
            var ltsRequests = new List<RequestData>();
            try
            {
                var requestCompany = await _Context.SolicitudEmpresa.Take(5).ToListAsync();
                if (requestCompany.Any())
                {
                    foreach (var itemImages in requestCompany)
                    {
                        List<string> imagesList = await _getListImages(itemImages.NombreContenedor, itemImages.IdSolicitud);
                        var user = await _Context.Usuario.Where(x => x.IdUsuario == itemImages.IdUsuario).FirstOrDefaultAsync();
                        ltsRequests.Add(new RequestData
                        {
                            City = itemImages.Ciudad,
                            DatePublish = itemImages.FechaPublicacion,
                            Departament = itemImages.Departamento,
                            RequestName = itemImages.NombreRequerimiento,
                            RequestDescription = itemImages.DescripcionRequerimiento,
                            StateRequest = itemImages.Estado,
                            Status = itemImages.EstadoVinculacion,
                            UserName = $"{user.Nombre} {user.Apellido}",
                            ImagesUrl = imagesList
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                ltsRequests.Add(new RequestData
                {
                    Status = ex.Message
                });
            }
            return ltsRequests;
        }
        public async Task<bool> InsertRequestUser(FormRequest formRequest) 
            => await _insertRequest(formRequest);
        public bool InsertListRequest(List<FormRequest> formRequest)
            => _insertListRequest(formRequest);
        private List<string[]> _getListTechnology(int idProyecto) 
        {
            var result = new List<string[]>();

            var frontTech = _Context.TecnologiasUtilizadas
                .Where(x => x.IdProyecto == idProyecto)
                .Select(x => x.TecnologiasFront.Replace("none-", ""))
                .FirstOrDefault().Split('-');

            var backTech = _Context.TecnologiasUtilizadas
                            .Where(x => x.IdProyecto == idProyecto)
                            .Select(x => x.TecnologiasBack.Replace("none-", ""))
                            .FirstOrDefault().Split('-');

            result.Add(frontTech);
            result.Add(backTech);
            return result;
        }
        private async Task<bool> _insertRequest(FormRequest formRequest) 
        {
            try
            {
                var datePost = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                var imagesData = new Dictionary<string, string>();
                string requestName = string.Concat(formRequest.RequestName.Where(c => !char.IsWhiteSpace(c)));
                string containerName = $"{requestName.ToLower()}-images";
                var images = new List<ImagenesSolicitud>();

                int numFile = 1;
                formRequest.FilesData.ForEach((item) =>
                {
                    string nombreImagen = $"{item.FileType.Replace("/", $"0{numFile}.")}";
                    images.Add(new ImagenesSolicitud()
                    {
                        ImagenOriginal = item.FileName,
                        NombreImagen = nombreImagen,
                        TipoImagen = item.FileType,
                        NombreContenedor = containerName
                    });
                    imagesData.Add(nombreImagen, item.FileStreamContent);
                    numFile++;
                });
                int result = _saveRequest(formRequest, images, containerName);
                if (result > 0)
                {
                    //Insertar Imagen azure storage 
                    await _azureBlob.SaveBlobImage(imagesData, containerName, false);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                string ms = ex.Message;
                return false;
            }
        }
        private bool _insertListRequest(List<FormRequest> formRequest) 
        {
            using (_Context) 
            {
                try
                {
                    int result = 0;
                    formRequest.ForEach(itemR =>
                    {
                        result = _saveRequest(itemR, null,"NoContainer");
                    });
                    return result > 0;
                }
                catch (Exception ex)
                {
                    string ms = ex.Message;
                    return false;
                }
            }
        }
        private int _saveRequest(FormRequest formRequest, List<ImagenesSolicitud> images, string containerName) 
        {
            string resultCateogry = _getCategory(formRequest.Category);
            var request = new List<SolicitudEmpresa>()
                {
                    new SolicitudEmpresa()
                    {
                            CategoriaRequerimiento = resultCateogry,
                            Ciudad = formRequest.City,
                            Departamento = formRequest.Department,
                            DescripcionRequerimiento = formRequest.RequestDescription,
                            EstadoVinculacion = "NoVinculado",
                            IdUsuario = formRequest.IdUser,
                            Estado = "Activo",
                            FechaPublicacion = DateTime.Now,
                            NombreRequerimiento = formRequest.RequestName,
                            ImagenesSolicitud = images,
                            NombreContenedor = containerName
                    }
                };

            var usuarioCreador = new UsuarioCreadorSolicitud()
            {
                FechaCreacion = DateTime.Now,
                IdCreador = formRequest.IdUser,
                NombreUsuario = formRequest.UserName,
                TipoUsuario = 1,
                SolicitudEmpresa = request
            };

            _Context.UsuarioCreadorSolicitud.Add(usuarioCreador);
            int result = _Context.SaveChanges();
            return result;
        }
        private string _getCategory(string numCategory) 
        {
            switch (numCategory)
            {
                case "01":
                    return "ArtAndDesign";
                case "02":
                    return "IndustryAndCommerce";
                case "03":
                    return "Education";
                case "04":
                    return "Environment";
                case "05":
                    return "EntertainmentAndEvents";
                case "06":
                    return "AgricultureAndFarms";
                case "07":
                    return "FinanceAndJobs";
                case "08":
                    return "FoodAndDelivery";
                case "09":
                    return "HealthAndWellness";
                case "10":
                    return "EstateAndHome";
                case "11":
                    return "BooksAndLibraries";
                case "12":
                    return "VehiclesAndMotorcycles";
                case "13":
                    return "MusicAndAudio";
                case "14":
                    return "OfficeComplement";
                case "15":
                    return "Photography";
                case "16":
                    return "SupermarketsAndStores";
                case "17":
                    return "ToolsAndProductivity";
                case "18":
                    return "Transport";
                case "19":
                    return "TravelsAndTourism";
                case "20":
                    return "Other";
                default:
                    return "Other";
            }
        }
        private async Task<List<string>> _getListImages(string container, int idSolicitud) 
        {
           var diccionary = new Dictionary<string, string>();
           var images = await _Context.ImagenesSolicitud.Where(x=> x.IdSolicitud == idSolicitud).ToListAsync();
            images.ForEach(x=> diccionary.Add(x.NombreImagen, x.TipoImagen));
            return await _azureBlob.GetImagesContainer(diccionary,container);

        }
    }
}
