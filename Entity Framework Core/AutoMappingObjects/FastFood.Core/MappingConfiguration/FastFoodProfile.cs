namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using FastFood.Services.DTO.Employee;
    using FastFood.Services.DTO.Position;
    using System.Linq;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<Position, EmployeeRegisterPositionAvailable>()
                .ForMember(x => x.PositionId, y => y.MapFrom(s => s.Id));

            //Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>();

            //Employees
            this.CreateMap<EmployeeRegisterPositionAvailable, RegisterEmployeeViewModel>();

            this.CreateMap<RegisterEmployeeViewModel, RegisterEmployeesDto>();

            this.CreateMap<RegisterEmployeesDto, Employee>();

            this.CreateMap<ListAllEmployeeDto, EmployeesAllViewModel>();

            this.CreateMap<Employee, ListAllEmployeeDto>()
                .ForMember(x => x.Position, y => y.MapFrom(s => s.Position.Name));
                
            //Orders
            //this.CreateMap<CreateOrderInputModel, Order>()
            //    .ForMember(x => x.OrderItems.Select(oi => oi.ItemId), y => y.MapFrom(s => s.ItemId))
            //    .ForMember(x => x.OrderItems.Select(oi => oi.Quantity) , y => y.MapFrom(s => s.Quantity));

            //this.CreateMap<CreateOrderViewModel, Order>()
            //    .ForMember(x => x.OrderItems, y => y.MapFrom(s => s.Items));
            //    .ForMember(x => x.Employee)
        }
    }
}
