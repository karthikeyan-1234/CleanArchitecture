using _01___Domain.Requests;

using _02___Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___Application.Contracts
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> AddEmployee(EmployeeDTO newEmp);
        Task<IEnumerable<EmployeeDTO>> GetAllEmployees();
        EmployeeDTO? FindEmployeeById(int id);
        void DeleteEmployee(int id);
        EmployeeDTO UpdateEmployee(EmployeeDTO Emp);
    }

}
