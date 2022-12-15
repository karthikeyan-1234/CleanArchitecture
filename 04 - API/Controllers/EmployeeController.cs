using _01___Domain.Requests;

using _02___Application.Contracts;
using _02___Application.DTOs;

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

        [HttpPost("AddEmployee",Name = "AddEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeeDTO newEmp)
        {
           var emp = await service.AddEmployee(newEmp);
           return Ok(emp);
        }
    }
}
