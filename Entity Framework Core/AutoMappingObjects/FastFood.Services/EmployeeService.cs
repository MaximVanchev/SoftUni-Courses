using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Core.ViewModels.Employees;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.DTO.Employee;
using FastFood.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFood.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public EmployeeService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.dbContext = context;
        }

        public void Register(RegisterEmployeesDto dto)
        {
            Employee employee = mapper.Map<Employee>(dto);

            this.dbContext.Employees.Add(employee);

            dbContext.SaveChanges();
        }

        public ICollection<ListAllEmployeeDto> All()
        => dbContext.Employees.ProjectTo<ListAllEmployeeDto>(mapper.ConfigurationProvider).ToList();
    }
}
