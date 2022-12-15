using _01___Domain.Requests;

using _02___Application.DTOs;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___Application.CQRS.Commands
{
    public class CreateEmployeeCommand : IRequest<EmployeeDTO>
    {
        public EmployeeDTO newEmp { get; set; }

        public CreateEmployeeCommand(EmployeeDTO newEmp)
        {
            this.newEmp = newEmp;
        }
    }
}
