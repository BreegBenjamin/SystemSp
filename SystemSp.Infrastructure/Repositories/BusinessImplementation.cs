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
using SystemSp.Infrastructure.Data;

namespace SystemSp.Infrastructure.Repositories
{
    public abstract class BusinessImplementation
    {
        private readonly SystemSpContext _Context;
        private readonly ISystemSpAzureBlob _azureBlob;
        public BusinessImplementation(SystemSpContext context, ISystemSpAzureBlob azureBlob )
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
                    string _categoria = string.Concat(appProject.Category.Where(c => !char.IsWhiteSpace(c)));
                    string _projectName = string.Concat(appProject.NameProject.Where(c => !char.IsWhiteSpace(c)));

                    var datePost = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    var dateProject = DateTime.Now;
                    DateTime.TryParse(appProject.ProjectDate, out dateProject);
                    
                    var images = new List<ImagenesProyecto>();
                    var team = new List<IntegrantesProyecto>();
                    var imagesData = new Dictionary<string, string>();

                    Usuario user = await _Context.Usuario.FirstOrDefaultAsync(
                        x => x.IdUsuario == appProject.UserId);

                    //Nombre del contenedor por proyecto
                    string container = $"{_projectName.ToLower()}-{Guid.NewGuid()}";

                    //Agrega a la lista que se guarda en la base de datos
                    int numImg = 1;
                    appProject.ImagesDataStream.ForEach(img => 
                    {
                        string nombreImagen = $"{img.ImageType.Replace("/", $"0{numImg}.")}";
                        images.Add(new ImagenesProyecto()
                        {
                            NombreImagen = nombreImagen,
                            ImagenOriginal = img.ImageName,
                            TipoImagen = img.ImageType,
                            NombreContenedor = container
                        });
                        imagesData.Add(nombreImagen, img.ImageStream);
                        numImg++;
                    });

                    //Insertar Imagen azure storage 
                    await _azureBlob.SaveBlobImage(imagesData, container);

                    //Insertar proyecto de formación
                    var formativeProject = new Proyecto()
                    {
                        IdUsuario = user.IdUsuario,
                        IdVinculacion = 0,
                        NombreProyecto = _projectName,
                        Categoria = _categoria,
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
                    await _Context.UsuarioCreadorProyecto.AddAsync(credor);
                    await _Context.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                }
                return result;
            }
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
                (x)=> x.IdAdmin == idAdmin);
            if (admin.ProyectosPublicados == 0)
                admin.ProyectosPublicados = 1;
            else
                admin.ProyectosPublicados = admin.ProyectosPublicados + 1;
            _Context.SaveChanges();
        }
        public async Task<bool> InsertFormativeProject(FormProjectApp appProject)
            => await _insertProject(appProject);
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
            using (_Context) 
            {
                var usuInfo = new UserInformation()
                {
                    MessageStates = new UserMessageStates()
                };
                try
                {
                    Usuario user = await _Context.Usuario.FirstOrDefaultAsync(
                        x=> x.DireccionEmail == login.EmailLogin && x.Contrasenia == login.PasswordLogin);
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
                catch (Exception)
                {
                    usuInfo.MessageStates.UserExist = false;
                }
                return usuInfo;
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
                        x=>x.IdPersona == updateData.IdApprentice && x.IdUsuarioCreador == updateData.IdUser
                        && x.IdProyecto == updateData.IdProject);
                    if (apprentice != null) 
                    {
                        apprentice.Estado = updateData.Estado;
                        apprentice.FechaActualizacion = DateTime.Now;
                        _Context.SaveChanges();
                        result = true;
                    }
                }
                catch{}
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
                bool salida = false;
                try
                {
                    var project = await _Context.Proyecto.FirstOrDefaultAsync(
                        (x)=> x.IdProyecto == updateData.IdProject && x.IdUsuario == updateData.IdUser
                        && x.Estado != "Eliminado");
                    if (project != null) 
                    {
                        if (updateData.Estado == "Eliminado")
                            project.FechaEliminado = DateTime.Now;
                        else if (updateData.Estado == "Actualizado")
                            project.FechaActualizacion = DateTime.Now;
                        project.Estado = updateData.Estado;
                        _Context.SaveChanges();
                    }
                }
                catch (Exception){}
                return salida;
            }
        }
        public async Task<List<string>> GetImagesAzureBlob(int IdProject) 
        {
            List<ImagenesProyecto> images = await _Context.ImagenesProyecto
                .Where(x => x.IdProyecto == IdProject).ToListAsync();
            var dicImages = new Dictionary<string,string>();

            images.ForEach(x => dicImages.Add(x.NombreImagen, x.TipoImagen));

            string container = await _Context.ImagenesProyecto
                .Where(x => x.IdProyecto == IdProject)
                .Select(x => x.NombreContenedor).FirstOrDefaultAsync();

            List<string> result = await _azureBlob.GetImagesContainer(dicImages, container);
            return result;
        }
        public async Task<List<string>> GetCategorys() 
        {
            var lstSalida = new List<string>();
            try
            {
                using (_Context)
                {
                    lstSalida = _Context.Proyecto.FromSqlRaw("spObtenerCategoriasPopulares")
                        .Select(x=> x.Categoria).ToList();
                }
            }
            catch (Exception ex)
            {
                lstSalida[0] = "NOK";
            }
            return lstSalida;
        }
    }
}
