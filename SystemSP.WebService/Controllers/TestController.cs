using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SystemSP.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IConfiguration _Configuration;
        public TestController(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        [HttpGet("{message}")]
        [ActionName(nameof(TestApp))]
        public IActionResult TestApp( string message)
        {
            return Ok($"This is the text from {message}");
        }

        [HttpGet]
        [ActionName(nameof(AppMessage))]
        public IActionResult AppMessage()
        {
            return Ok($"{_Configuration["TextPrueba"]}");
        }
    }
}
