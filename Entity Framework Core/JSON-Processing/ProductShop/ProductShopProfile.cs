using AutoMapper;
using ProductShop.DTO.Category;
using ProductShop.DTO.Product;
using ProductShop.DTO.User;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Product
            CreateMap<Product, ProductSellerViewDto>()
                .ForMember(x => x.Seller , y => y.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            CreateMap<Product, SoldProductViewDto>()
               .ForMember(x => x.BuyerFirstName, y => y.MapFrom(s => s.Buyer.FirstName))
               .ForMember(x => x.BuyerLastName, y => y.MapFrom(s => s.Buyer.LastName));

            CreateMap<Product, ProductNamePriceViewDto>()
                .ForMember(x => x.Price , y => y.MapFrom(s => s.Price.ToString("F2")));

            CreateMap<User, ProductsCountViewDto>()
                .ForMember(x => x.Products, y => y.MapFrom(s => s.ProductsSold));
           
            //User
            CreateMap<User, UserSoldProductsViewDto>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(s => s.ProductsSold));

            CreateMap<User, UserWithProductsViewDto>()
                .ForMember(x => x.SoldProducts , y => y.MapFrom(s => new { }));

            //Category
            CreateMap<Category, CategoryViewDto>()
                .ForMember(x => x.ProductsCount, y => y.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(x => x.AveragePrice, y => y.MapFrom(s => s.CategoryProducts.Select(c => c.Product.Price).DefaultIfEmpty(0).Average().ToString("F2")))
                .ForMember(x => x.TotalRevenue, y => y.MapFrom(s => s.CategoryProducts.Select(c => c.Product.Price).Sum().ToString("F2")));
        }
    }
}
