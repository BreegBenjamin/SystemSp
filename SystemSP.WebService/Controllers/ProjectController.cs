using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SystemSp.Core.Interfaces;

namespace SystemSP.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ISystemSPConecction _context;
        public ProjectController(ISystemSPConecction context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getProject()
        {
            var result = await _context.GetPopularProject();
            return Ok(result);
        }
    }
}
