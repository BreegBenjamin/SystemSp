using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SystemSp.Core.Interfaces;
using SystemSp.DTOS.EntitisProjectsApp;

namespace SystemSP.WebService.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ISystemSPConecction _service;
        public PersonController(ISystemSPConecction service)
        {
            _service = service;
        }
        [HttpPost]
        [ActionName("ChangeStatusAprentice")]
        public async Task<IActionResult> ChangeStatusAprentice(UpdateDataProject updateData) 
        {
            var result = await _service.StatusAprentice(updateData); 
            return Ok(result);
        }
        [HttpPost]
        [ActionName("UpDatePerson")]
        public async Task<IActionResult> UpDataPerson(UpdateDataProject updateData)
        {
            var result = await _service.UpDataPerson(updateData);
            return Ok(result);
        }
        [HttpPost]
        [ActionName("UpDateProject")]
        public async Task<IActionResult> UpDateProject(UpdateDataProject updateData)
        {
            var result = await _service.UpDateProject(updateData);
            return Ok(result);
        }
        [HttpPost]
        [ActionName("ValidateEmail")]
        public async Task<IActionResult> ValidateEmail([FromBody] string email) 
        {
            bool salida = await _service.ValidaEmailUser(email);
            return Ok(salida);
        }
    }
}
