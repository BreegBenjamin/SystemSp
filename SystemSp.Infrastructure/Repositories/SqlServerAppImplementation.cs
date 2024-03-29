﻿using Microsoft.EntityFrameworkCore;
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
        public SqlServerAppImplementation(SystemSpContext context, ISystemSpAzureBlob azureBlob) : base(context, azureBlob)
        {
        }
        async Task<ProjectInformation> ISystemSPConecction.GetFormativeProject(int idProject)
            => await GetFormativeProject(idProject);

        async Task<IEnumerable<ProjectInformation>> ISystemSPConecction.GetLastProjects()
            => await GetProjects();

        async Task<FeaturedProjects> ISystemSPConecction.GetPopularProjects()
            => await GetPopularProjects();
        async Task<bool> ISystemSPConecction.InsertProject(FormProjectApp appProject)
         => await InsertFormativeProject(appProject);
        async Task<UserInformation> ISystemSPConecction.GetUserApp(FormLogin login)
            => await UserResponse(login);

        public async Task<IEnumerable<UserInformation>> GetLastUsers()
            => await GetUsers();
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
        Task<bool> ISystemSPConecction.PostRequest(FormRequest request)
            => InsertRequestUser(request);
        bool ISystemSPConecction.PostListRequest(List<FormRequest> request)
            => InsertListRequest(request);
        async Task<List<ReportApp>> ISystemSPConecction.GetListReport()
            => await GetReports();
        async Task<List<InformationDocuments>> ISystemSPConecction.GetUriDocuments(int idProject)
            => await GetDocumentUri(idProject);

        public async Task<IEnumerable<RequestData>> GetListRequest()
            => await GetRequests();
    }
}
