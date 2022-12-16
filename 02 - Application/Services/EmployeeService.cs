using _01___Domain.Models;
using _01___Domain.Requests;

using _02___Application.Contracts;
using _02___Application.CQRS.Commands;
using _02___Application.DTOs;
using AutoMapper;

using MediatR;

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
        IMediator mediator;
        IMapper mapper;
        ILogger logger;
        ICacheManager cacheManager;

        public EmployeeService(IGenericRepository<Employee> empRepo,IMapper mapper,ILogger logger,IMediator mediator,ICacheManager cacheManager)
        {
            this.empRepo = empRepo;
            this.mapper = mapper;
            this.logger = logger;
            this.mediator = mediator;
            this.cacheManager = cacheManager;
        }

        public async Task<EmployeeDTO> AddEmployee(EmployeeDTO newEmp)
        {
            var emp = await mediator.Send(new CreateEmployeeCommand(newEmp));

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
            var res = await empRepo.GetAllAsync();
            await cacheManager.TrySetAsync("getall", res);
            return mapper.Map<IEnumerable<EmployeeDTO>>(res);
        }

        public EmployeeDTO UpdateEmployee(EmployeeDTO Emp)
        {
            throw new NotImplementedException();
        }
    }
}
