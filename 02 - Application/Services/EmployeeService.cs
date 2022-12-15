using _01___Domain.Models;
using _01___Domain.Requests;

using _02___Application.Contracts;
using _02___Application.DTOs;
using AutoMapper;

using Serilog;
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
        ILogger logger;

        public EmployeeService(IGenericRepository<Employee> empRepo,IMapper mapper,ILogger logger)
        {
            this.empRepo = empRepo;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<EmployeeDTO> AddEmployee(EmployeeDTO newEmp)
        {
            var emp = await empRepo.AddAsync(mapper.Map<Employee>(newEmp));
            await empRepo.SaveChangesAsync();
            logger.Information("Employee {0} added",newEmp.name);
            return mapper.Map<EmployeeDTO>(emp);
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public EmployeeDTO? FindEmployeeById(int id)
        {
            var emp = empRepo.GetByID(id);

            if (emp != null)
                return mapper.Map<EmployeeDTO>(emp);

            return null;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            return mapper.Map<IEnumerable<EmployeeDTO>>(await empRepo.GetAllAsync());
        }

        public EmployeeDTO UpdateEmployee(EmployeeDTO Emp)
        {
            throw new NotImplementedException();
        }
    }
}
