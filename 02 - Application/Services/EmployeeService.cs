using _01___Domain.Models;
using _02___Application.Contracts;
using _02___Application.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        IGenericRepository<Employee> empRepo;
        IMapper mapper;

        public EmployeeService(IGenericRepository<Employee> empRepo,IMapper mapper)
        {
            this.empRepo = empRepo;
            this.mapper = mapper;
        }

        public async Task<EmployeeDTO> AddEmployee(EmployeeDTO newEmp)
        {
            var emp = await empRepo.AddAsync(mapper.Map<Employee>(newEmp));
            await empRepo.SaveChangesAsync();
            return mapper.Map<EmployeeDTO>(emp);
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public EmployeeDTO FindEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public EmployeeDTO UpdateEmployee(EmployeeDTO Emp)
        {
            throw new NotImplementedException();
        }
    }
}
