using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SystemSp.Core.Interfaces;

namespace SystemSP.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ISystemSPConecction _context;

        public CategoryController(ISystemSPConecction context)
        {
            _context = context;
        }

        [ActionName("GetPopularCategory")]
        public async Task<IActionResult> GetPopularCategory() 
        {
            var result = await _context.GetPopularCategory();
            return Ok(result);
        }
    }
}
