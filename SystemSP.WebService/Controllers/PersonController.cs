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
        private readonly ISystemSPConecction _context;
        public PersonController(ISystemSPConecction context)
        {
            _context = context;
        }

        [ActionName("ChangeStatusAprentice")]
        public async Task<IActionResult> ChangeStatusAprentice(UpdateDataProject updateData) 
        {
            var result = await _context.StatusAprentice(updateData); 
            return Ok(result);
        }

        [ActionName("UpDatePerson")]
        public async Task<IActionResult> UpDataPerson(UpdateDataProject updateData)
        {
            var result = await _context.UpDataPerson(updateData);
            return Ok(result);
        }

        [ActionName("UpDateProject")]
        public async Task<IActionResult> UpDateProject(UpdateDataProject updateData)
        {
            var result = await _context.UpDateProject(updateData);
            return Ok(result);
        }
    }
}
