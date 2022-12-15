using _02___Application.Contracts;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _04___API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet("GetallEmployees",Name = "GetAllEmployees")]
        public async Task<IActionResult> GetallEmployees()
        {
            return Ok(await service.GetAllEmployees());
        }
    }
}
