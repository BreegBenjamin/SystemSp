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
    public class SqlServerAppImplementation : BusinessImplementation, ISystemSPConecction
    {
        private readonly SystemSpContext _Context;

        private readonly ISystemSpAzureBlob _azureBlob;
        public SqlServerAppImplementation(SystemSpContext context, ISystemSpAzureBlob azureBlob) : base(context, azureBlob)
        {
            _Context = context;
            _azureBlob = azureBlob;
        }
        async Task<ProjectInformation> ISystemSPConecction.GetFormativeProject(int idProject)
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
                    }
                }
                catch{ }
                return project;
            }
        }
        async Task<FeaturedProjects> ISystemSPConecction.GetPopularProjects()
        {
            using (_Context)
            {
                var popularProject = new FeaturedProjects();
                try
                {
                    List<Proyecto> project = await _Context.Proyecto.Take(10)
                        .Where((x)=> x.Estado != "Eliminado").ToListAsync();
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
        async Task<bool> ISystemSPConecction.InsertProject(FormProjectApp appProject)
         => await InsertFormativeProject(appProject);
        async Task<UserInformation> ISystemSPConecction.GetUserApp(FormLogin login)
            => await UserResponse(login);
        async Task<List<ProjectDetails>> ISystemSPConecction.GetProjectsUser(int IdUser)
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
                catch (Exception){}
                return result;
            }
        }
        async Task<UserInformation> ISystemSPConecction.InsertUser(FormRegister formLogin)
            => await InsertUserRol(formLogin);
        async Task<bool> ISystemSPConecction.StatusAprentice(UpdateDataProject updateData)
            => await ChangeStatusPerson(updateData);
        async Task<bool> ISystemSPConecction.UpDataPerson(UpdateDataProject updateData)
            => await ChangeInformationPerson(updateData);
        async Task<bool> ISystemSPConecction.UpDateProject(UpdateDataProject updateData)
                => await ChangeProjectState(updateData);

        public async Task<List<string>> GetPopularCategory()
               => await GetCategorys();
    }
}
