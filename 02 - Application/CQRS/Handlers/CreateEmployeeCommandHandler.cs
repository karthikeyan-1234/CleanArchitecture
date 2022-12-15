using _01___Domain.Models;
using _01___Domain.Requests;

using _02___Application.Contracts;
using _02___Application.CQRS.Commands;
using _02___Application.DTOs;

using AutoMapper;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___Application.CQRS.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDTO>
    {
        IGenericRepository<Employee> repo;
        IMapper mapper;

        public CreateEmployeeCommandHandler(IGenericRepository<Employee> repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<EmployeeDTO> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var newEmp = await repo.AddAsync(mapper.Map<Employee>(request.newEmp));
            await repo.SaveChangesAsync();
            return mapper.Map<EmployeeDTO>(newEmp);
        }
    }
}
