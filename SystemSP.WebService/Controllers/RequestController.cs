using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemSp.Core.Interfaces;
using SystemSp.DTOS.EntitisFormsApp;

namespace SystemSP.WebService.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ISystemSPConecction _context;
        public RequestController(ISystemSPConecction context) 
        {
            _context = context;
        }

        [HttpPost]
        [ActionName("InsertRequest")]
        public async Task<IActionResult> InsertRequest([FromBody] FormRequest request) 
        {
            bool salida = await _context.PostRequest(request);
            return Ok(salida);
        }

        [HttpGet]
        [ActionName("GetFeaturedRequest")]
        public async Task<IActionResult> GetFeaturedRequest()
        {
            var result = await _context.GetListRequest();
            return Ok(result);
        }

        [HttpPost]
        [ActionName("PostListRequest")]
        public IActionResult PostListRequest([FromBody] List<FormRequest> request)
        {
            bool salida = _context.PostListRequest(request);
            return Ok(salida);
        }
    }
}
