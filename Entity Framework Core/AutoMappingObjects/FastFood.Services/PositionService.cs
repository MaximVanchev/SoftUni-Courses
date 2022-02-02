using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Services.DTO.Position;
using FastFood.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood.Services
{
    public class PositionService : IPositionService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public PositionService(IMapper mapper , FastFoodContext context)
        {
            this.mapper = mapper;
            this.dbContext = context;
        }

        public ICollection<EmployeeRegisterPositionAvailable> GetPositionsAvailable()
        => this.dbContext.Positions.ProjectTo<EmployeeRegisterPositionAvailable>(mapper.ConfigurationProvider).ToList();
    }
}
