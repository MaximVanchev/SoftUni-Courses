namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Services.DTO.Employee;
    using FastFood.Services.DTO.Position;
    using FastFood.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly IPositionService positionService;
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeesController(IMapper mapper , IPositionService positionService , IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
            this.positionService = positionService;
            this.mapper = mapper;
        }

        public IActionResult Register()
        {
            ICollection<EmployeeRegisterPositionAvailable> positionDto = positionService.GetPositionsAvailable();

            List<RegisterEmployeeViewModel> regViewModel = mapper.Map<ICollection<EmployeeRegisterPositionAvailable> , 
                ICollection<RegisterEmployeeViewModel>>(positionDto)
                .ToList();

            return this.View(regViewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Register");
            }

            RegisterEmployeesDto employeeDto = this.mapper.Map<RegisterEmployeesDto>(model);

            employeeService.Register(employeeDto);

            return this.RedirectToAction("All", "Employees");
        }

        public IActionResult All()
        {
            ICollection<ListAllEmployeeDto> employeesDtos = employeeService.All();

            List<EmployeesAllViewModel> employeesViewModel = mapper
               .Map<ICollection<ListAllEmployeeDto> , ICollection<EmployeesAllViewModel>>(employeesDtos).ToList();

            return this.View("All" , employeesViewModel);
        }
    }
}
