using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SystemSp.DTOS.EntitisIndexApp;
using SystemSp.Intellengece.Entities;
using SystemSp.Intellengece.Interfaces;

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
                new FeaturedProjects(), Controllers.Project);
            return projects;
        }
        public async Task<FeaturedProjects> GetFeaturedProjects()
            => await _getFeaturedProject();
    }
}
