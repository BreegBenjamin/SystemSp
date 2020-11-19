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
            => await GetFormativeProject(idProject);
        async Task<FeaturedProjects> ISystemSPConecction.GetPopularProjects()
            => await GetPopularProjects();
        async Task<bool> ISystemSPConecction.InsertProject(FormProjectApp appProject)
         => await InsertFormativeProject(appProject);
        async Task<UserInformation> ISystemSPConecction.GetUserApp(FormLogin login)
            => await UserResponse(login);
        async Task<List<ProjectDetails>> ISystemSPConecction.GetProjectsUser(int IdUser)
            => await GetProjectsUser(IdUser);
        async Task<UserInformation> ISystemSPConecction.InsertUser(FormRegister formLogin)
            => await InsertUserRol(formLogin);
        async Task<bool> ISystemSPConecction.StatusAprentice(UpdateDataProject updateData)
            => await ChangeStatusPerson(updateData);
        async Task<bool> ISystemSPConecction.UpDataPerson(UpdateDataProject updateData)
            => await ChangeInformationPerson(updateData);
        async Task<bool> ISystemSPConecction.UpDateProject(UpdateDataProject updateData)
                => await ChangeProjectState(updateData);
        async Task<List<string>> ISystemSPConecction.GetPopularCategory()
               => await GetPopularCategory();
        async Task<bool> ISystemSPConecction.ValidaEmailUser(string email)
            => await ValidaEmailUser(email);
    }
}
