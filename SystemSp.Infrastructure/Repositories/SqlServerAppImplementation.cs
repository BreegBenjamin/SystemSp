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
        public SqlServerAppImplementation(SystemSpContext context) : base(context)
        {
            _Context = context;
        }
        async Task<ProjectInformation> ISystemSPConecction.GetFormativeProject(int id)
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
                        .FirstOrDefaultAsync(x => x.IdProyecto == id);
                    if (formativeProject != null)
                    {
                        formativeProject.ImagenesProyecto = await _Context.ImagenesProyecto
                            .Where(x => x.IdProyecto == formativeProject.IdProyecto)
                            .ToListAsync();
                        ProjectCard card = GetCard(formativeProject);
                        foreach (var item in formativeProject.ImagenesProyecto)
                        {
                            string imageProject = Encoding.UTF8.GetString(
                                item.Imagen, 0, item.Imagen.Length);
                            project.ImagesProject.Add(imageProject);
                        }
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
                    List<Proyecto> project = await _Context.Proyecto.Take(6).ToListAsync();
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
        {
            bool result = await InsertFormativeProject(appProject);
            return result;
        }
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
                        (x) => x.IdUsuario == IdUser).ToListAsync();
                    if (projectSalida != null && projectSalida.Count > 0) 
                    {
                        //Llenando los tedalles del proyecto por cada resultado de la
                        //Consulta
                        int _contador = 0;
                        projectSalida.ForEach((iVal) =>
                        {
                            var project = new ProjectDetails() 
                            {
                                ImagenesProyecto = new List<string>(),
                                Aprendices = new List<ApprenticeData>()
                            };
                            var integrantes = _Context.IntegrantesProyecto.Where(
                                x=> x.IdUsuarioCreador == iVal.IdUsuario && x.Estado == "Activo").ToList();
                            var imagenes = _Context.ImagenesProyecto.Where(
                                x => x.IdProyecto == iVal.IdProyecto).ToList();

                            project.Descripcion = iVal.DescripcionProyecto;
                            project.Categoria = iVal.Categoria;
                            project.IdProyecto = iVal.IdProyecto;
                            project.NombreProyecto = iVal.NombreProyecto;
                            project.NumeroDescargas = iVal.NumeroDescargas.ToString();
                            project.NumeroVistas = iVal.NumeroVisitas.ToString();
                            imagenes.ForEach(x =>
                            {
                                string imageProject = Encoding.UTF8.GetString(
                                    x.Imagen, 0, x.Imagen.Length);
                                project.ImagenesProyecto.Add(imageProject);
                            });
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
                            _contador++;
                        });
                    }
                }
                catch (Exception)
                {

                }
                return result;
            }
        }
        async Task<UserInformation> ISystemSPConecction.InsertUser(FormRegister formLogin)
            => await InsertUserRol(formLogin);
        async Task<bool> ISystemSPConecction.StatusAprentice(UpdateDataProject updateData)
            => await ChangeStatusPerson(updateData);
        async Task<bool> ISystemSPConecction.UpDataPerson(UpdateDataProject updateData)
            => await ChangeInformationPerson(updateData);
    }
}
