using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SystemSp.Core.Interfaces;
using SystemSp.DTOS.EntitisFormsApp;

namespace SystemSP.WebService.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISystemSPConecction _context;
        public UsersController(ISystemSPConecction context) 
        {
            _context = context;
        }
        [HttpPost]
        [ActionName("GetUser")]
        public async Task<IActionResult> GetUser([FromBody] FormLogin login) 
        {
            var salida = await _context.GetUserApp(login);
            return Ok(salida);
        }

        [HttpPost]
        [ActionName("InsertUser")]
        public async Task<IActionResult> PostProjectUser([FromBody] FormRegister ProjectDate)
        {
            var result = await _context.InsertUser(ProjectDate);
            return Ok(result);
        }
    }
}
