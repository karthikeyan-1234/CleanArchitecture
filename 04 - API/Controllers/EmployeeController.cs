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
        IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost("AddEmployee",Name = "AddEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeeDTO newEmp)
        {
            var emp = await employeeService.AddEmployee(newEmp);
            return CreatedAtAction(nameof(GetEmployeeById), emp.id);
        }

        [HttpGet("GetEmpByID",Name ="GetEmpById")]
        public IActionResult GetEmployeeById(int id)
        {
            var emp = employeeService.FindEmployeeById(id);

            if(emp == null)
               return NotFound();

            return Ok(emp);
        }
    }
}
