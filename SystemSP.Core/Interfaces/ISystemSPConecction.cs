using System.Collections.Generic;
using System.Threading.Tasks;
using SystemSp.DTOS.EntitisFormsApp;
using SystemSp.DTOS.EntitisIndexApp;
using SystemSp.DTOS.EntitisProjectsApp;
using SystemSp.DTOS.EntitisViewApp;

namespace SystemSp.Core.Interfaces
{
    public interface ISystemSPConecction
    {
        Task<UserInformation> GetUserApp(FormLogin login);
        Task<IEnumerable<UserInformation>> GetLastUsers();
        Task<FeaturedProjects> GetPopularProjects();
        Task<ProjectInformation> GetFormativeProject(int id);
        Task<IEnumerable<ProjectInformation>> GetLastProjects();
        Task<bool> InsertProject(FormProjectApp appProject);
        Task<List<ProjectDetails>> GetProjectsUser(int IdUser);
        Task<UserInformation> InsertUser(FormRegister formLogin);
        Task<bool> StatusAprentice(UpdateDataProject updateData);
        Task<bool> UpDataPerson(UpdateDataProject updateData);
        Task<bool> UpDateProject(UpdateDataProject updateData);
        Task<List<string>> GetPopularCategory();
        Task<bool> ValidaEmailUser(string email);
        Task<bool> PostRequest(FormRequest request);
        bool PostListRequest(List<FormRequest> request);
        Task<List<ReportApp>> GetListReport();
    }
}
