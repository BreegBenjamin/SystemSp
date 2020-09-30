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
        Task<FeaturedProjects> GetPopularProjects();
        Task<ProjectInformation> GetFormativeProject(int id);
        Task<bool> InsertProject(FormProjectApp appProject);
        Task<List<ProjectDetails>> GetProjectsUser(int IdUser);
        Task<UserInformation> InsertUser(FormRegister formLogin);
        Task<bool> StatusAprentice(UpdateDataProject updateData);
        Task<bool> UpDataPerson(UpdateDataProject updateData);
    }
}
