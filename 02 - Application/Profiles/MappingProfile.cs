using _01___Domain.Models;
using _01___Domain.Requests;

using _02___Application.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___Application.Profiles
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee,EmployeeDTO>();

            CreateMap<AddEmployeeRequest, Employee>();
            CreateMap<Employee, AddEmployeeRequest>();

            CreateMap<AddEmployeeRequest, EmployeeDTO>();
            CreateMap<EmployeeDTO, AddEmployeeRequest>();
        }
    }
}
