using System.Collections.Generic;
using System.Threading.Tasks;
using SystemSp.Core.Entities;
using SystemSp.DTOS.EntitisIndexApp;

namespace SystemSp.Core.Interfaces
{
    public interface ISystemSPConecction
    {
        Task<IEnumerable<UserApp>> GetUserApp();
        Task<UserApp> GetUsersAdmin(int idUser);
        Task<FeaturedProjects> GetPopularProject();
    }
}
