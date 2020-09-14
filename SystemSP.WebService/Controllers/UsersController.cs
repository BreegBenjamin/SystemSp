using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SystemSp.Core.Interfaces;

namespace SystemSP.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISystemSPConecction _context;
        public UsersController(ISystemSPConecction context) 
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetUser() 
        {
            var salida = await _context.GetUserApp();
            return Ok(salida);
        }
        
    }
}
