using System.Net.Http;
using System.Threading.Tasks;
using SystemSp.DTOS.EntitisIndexApp;
using SystemSp.DTOS.EntitisViewApp;
using SystemSp.DTOS.EntitisFormsApp;
using System.Collections.Generic;
using SystemSp.DTOS.EntitisProjectsApp;

namespace SystemSp.Intellengece.WebServiceBusiness
{
    public class ProjectsApplication : ServiceConecction
    {
        public ProjectsApplication(HttpClient client) : base(client) 
        {
        }
        private async Task<FeaturedProjects> _getFeaturedProject() 
        {
            var projects = await GetDataFromService(
                new FeaturedProjects(), "project/GetFeaturedProjects");
            return projects;
        }
        private async Task<ProjectInformation> _getProject(int projectId) 
        {
            var project = await GetDataFromService(
                new ProjectInformation(), $"project/GetProjectForId/{projectId}");
            return project;
        }
        public async Task<FeaturedProjects> GetFeaturedProjects()
            => await _getFeaturedProject();
        public async Task<ProjectInformation> GetProject(int projectId)
            => await _getProject(projectId);
        public async Task<bool> PostProject(FormProjectApp projectApp)
            => await SendDataToService(projectApp, "project/PostProjectUser");
        public async Task<List<ProjectDetails>> GetProjectsUser(int userId)
        {
            var salida = await GetDataFromService(
                new List<ProjectDetails>(), $"project/GetProjectsUser/{userId}");
            return salida;
        }
        public async Task<UserInformation> PostUser(FormRegister register)
         => await SendDataToServiceParam<FormRegister, UserInformation>(register, "Users/InsertUser");
        public async Task<UserInformation> GetUserApp(FormLogin login)
         => await SendDataToServiceParam<FormLogin, UserInformation>(login, "Users/GetUser");
        public async Task<bool> DeleteApprentice(UpdateDataProject updateData)
            => await SendDataToService(updateData, "Person/ChangeStatusAprentice");
        public async Task<bool> UpDateApprentice(UpdateDataProject updateData)
               => await SendDataToService(updateData, "Person/UpDatePerson");
        public async Task<bool> UpDateProject(UpdateDataProject updateData)
               => await SendDataToService(updateData, "Person/UpDateProject");
    }
}

