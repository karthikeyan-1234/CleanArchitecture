using _02___Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("GetAllEmployees",Name = "GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            return Ok(employeeService.GetAllEmployees());
        }
    }
}
