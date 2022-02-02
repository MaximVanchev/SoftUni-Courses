using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.DTO.Car;
using CarDealer.DTO.Customers;
using CarDealer.DTO.Part;
using CarDealer.DTO.Supplier;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {

            //CreateMap<Customer, OrderedCustomerDto>()
                //.ForMember(x => x.BirthDate, y => y.MapFrom(s => DateTime.ParseExact($"{s.BirthDate:dd/MM/yyyy}","dd/MM/yyyy",null)));

            CreateMap<Car, CarFromMakeDto>();

            CreateMap<Supplier, LocalSupplierDto>()
                .ForMember(x => x.PartsCount, y => y.MapFrom(s => s.Parts.Count));

            CreateMap<Car, CarPartsDto>()
                .ForMember(x => x.Parts, y => y.MapFrom(s => s.PartCars.Select(p => p.Part)));

            CreateMap<Car, CarMakeModelTravelledDto>();

            //CreateMap<Car, CarWithPartsDto>()
                //.ForMember(x => x.parts, y => y.MapFrom(s => s.PartCars.Select(p => p.Part)));
        }
    }
}
