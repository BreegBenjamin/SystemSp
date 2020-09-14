using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemSp.Core.Entities;
using SystemSp.Core.Interfaces;
using SystemSp.DTOS.EntitisIndexApp;
using SystemSp.Infrastructure.Data;

namespace SystemSp.Infrastructure.Repositories
{
    public class SqlServerAppImplementation : ISystemSPConecction
    {
        private readonly SystemSpContext _Context;
        public SqlServerAppImplementation(SystemSpContext context)
        {
            _Context = context;
        }

        public async Task<FeaturedProjects> GetPopularProject()
        {
            using (_Context)
            {
                var popularProject = new FeaturedProjects();
                try
                {
                    List<FormativeProject> project = await _Context.FormativeProject
                        .Take(6).ToListAsync();
                    var card = new List<ProjectCard>();
                    project.ForEach(item =>
                    {
                         UserApp user= _Context.UserApp.FirstOrDefault(
                             x=> x.IdUser == item.IdUser);
                        string imageUser = Encoding.UTF8.GetString(
                            user.ImageUser, 0, user.ImageUser.Length);
                        card.Add(new ProjectCard() 
                        {
                            IdProyecto = item.IdProject,
                            Categoria = item.Category,
                            NombreUsuario = $"{user.UserName} {user.UserLastName}",
                            TituloProyecto = item.ProjectName,
                            ImagenUsuario = imageUser
                        });
                    });
                    popularProject.ProjectCardList = card;
                    return popularProject;
                }
                catch (Exception ex)
                {
                    string mens = ex.Message;
                    return popularProject;
                }
            }
        }

        async Task<IEnumerable<UserApp>> ISystemSPConecction.GetUserApp()
        {
            using (_Context)
            {
                var users = await _Context.UserApp.ToListAsync();
                return users;
            }
        }
        async Task<UserApp> ISystemSPConecction.GetUsersAdmin(int id)
        {
            using (_Context)
            {
                try
                {
                    UserApp users = await _Context.UserApp.FirstOrDefaultAsync(
                   (x) => x.IdUser == id);
                    if (users.UserType == 1)
                    {
                        var admin = await _Context.UserAdmin
                            .FirstOrDefaultAsync((x) => x.IdAdmin == 1);
                        users.UserAdmin.Add(admin);
                    }
                    return users;
                }
                catch (Exception ex) 
                {
                    string menss = ex.Message;
                    return new UserApp();
                }
            }
        }
    }
}
