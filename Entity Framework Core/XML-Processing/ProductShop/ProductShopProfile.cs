using AutoMapper;
using ProductShop.DTO.Category;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserImportDto , User>();

            CreateMap<ProductImportDto, Product>()
                .ForMember(x => x.Price, y => y.MapFrom(s => Convert.ToDecimal(s.Price)));

            CreateMap<CategoryProductImportDto, CategoryProduct>();

            CreateMap<CategoryImportDto, Category>();

            CreateMap<Category, CategoryDto>()
                .ForMember(x => x.ProductsCount, y => y.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(x => x.AveragePrice, y => y.MapFrom(s => s.CategoryProducts.Select(c => c.Product.Price).DefaultIfEmpty(0).Average().ToString()))
                .ForMember(x => x.TotalRevenue, y => y.MapFrom(s => s.CategoryProducts.Select(c => c.Product.Price).Sum().ToString()));
        }
    }
}
