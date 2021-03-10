using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SystemSp.Core.Interfaces;
using SystemSp.DTOS.EntitisFormsApp;

namespace SystemSP.WebService.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ISystemSPConecction _context;
        public ProjectController(ISystemSPConecction context) 
        {
            _context = context;
        }
        
        [HttpGet]
        [ActionName("GetFeaturedProjects")]
        public async Task<IActionResult> GetFeaturedProjects()
        {
            var result = await _context.GetPopularProjects();
            return Ok(result);
        }

        [HttpGet("{IdProject}")]
        [ActionName("GetProjectForId")]
        public async Task<IActionResult> GetProjectForId(int IdProject) 
        {
            var result = await _context.GetFormativeProject(IdProject);
            return Ok(result);
        }
        [HttpGet]
        [ActionName("GetLastProject")]
        public async Task<IActionResult> GetLastProject() 
        {
            var result = await _context.GetLastProjects();
            return Ok(result);
        }

        [HttpGet("{IdUser}")]
        [ActionName("GetProjectsUser")]
        public async Task<IActionResult> GetProjectsUser(int IdUser) 
        {
            var result = await _context.GetProjectsUser(IdUser);
            return Ok(result);
        }

        [HttpPost]
        [ActionName("PostProjectUser")]
        public async Task<IActionResult> PostProjectUser([FromBody] FormProjectApp ProjectDate) 
        {
            bool result = await _context.InsertProject(ProjectDate);
            return Ok(result);
        }
    }
}
