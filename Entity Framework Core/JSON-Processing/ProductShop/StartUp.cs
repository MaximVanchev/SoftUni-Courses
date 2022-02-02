using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTO.Category;
using ProductShop.DTO.Product;
using ProductShop.DTO.User;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext dbContext = new ProductShopContext();

            //dbContext.Database.EnsureCreated();
            //dbContext.Database.EnsureDeleted();
            //Console.WriteLine(ImportUsers(dbContext, File.ReadAllText("../../../Datasets/users.json")));
            //Console.WriteLine(ImportProducts(dbContext, File.ReadAllText("../../../Datasets/products.json")));
            //Console.WriteLine(ImportCategories(dbContext, File.ReadAllText("../../../Datasets/categories.json")));
            //Console.WriteLine(ImportCategoryProducts(dbContext, File.ReadAllText("../../../Datasets/categories-products.json")));
            //Console.WriteLine(GetProductsInRange(dbContext));
            //Console.WriteLine(GetSoldProducts(dbContext));
            //Console.WriteLine(GetCategoriesByProductsCount(dbContext));
            Console.WriteLine(GetUsersWithProducts(dbContext));
        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ICollection<User> users = JsonConvert.DeserializeObject<ICollection<User>>(inputJson);

            foreach (var user in users)
            {
                context.Add(user);
            }

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ICollection<Product> products = JsonConvert.DeserializeObject<ICollection<Product>>(inputJson);

            context.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ICollection<Category> categories = JsonConvert.DeserializeObject<ICollection<Category>>(inputJson)
                .Where(c => c.Name != null).ToArray();

            foreach (var category in categories)
            {
                context.Add(category);
            }

            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ICollection<CategoryProduct> categoryProducts = JsonConvert.DeserializeObject<ICollection<CategoryProduct>>(inputJson);

            foreach (var categoryProduct in categoryProducts)
            {
                context.Add(categoryProduct);
            }

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = InitializeMapper();

            ICollection<Product> products = context.Products.Include(p => p.Seller).Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(c => c.Price).ToList();

            ICollection<ProductSellerViewDto> productViewDtos = mapper.Map<ICollection<ProductSellerViewDto>>(products);

            string result = JsonConvert.SerializeObject(productViewDtos , JsonSettings());
            
            return result;
        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            IMapper mapper = InitializeMapper();

            ICollection<User> users = context.Users.Include(u => u.ProductsSold).ThenInclude(p => p.Buyer)
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName).ThenBy(u => u.FirstName).ToList();

            ICollection<UserSoldProductsViewDto> userViewDtos = mapper.Map<ICollection<User>, ICollection<UserSoldProductsViewDto>>(users);

            string result = JsonConvert.SerializeObject(userViewDtos, JsonSettings());

            return result;
            //var soldProducts = context.Users
            //   .Where(x => x.ProductsSold.Count > 0)
            //   .Select(x => new
            //   {
            //       firstName = x.FirstName,
            //       lastName = x.LastName,
            //       soldProducts = x.ProductsSold.Select(p => new
            //       {
            //           name = p.Name,
            //           price = p.Price,
            //           buyerFirstName = p.Buyer.FirstName,
            //           buyerLastName = p.Buyer.LastName
            //       }).Where(s => s.buyerLastName != null)
            //       .ToList()
            //   })
            //   .OrderBy(x => x.lastName)
            //   .ThenBy(x => x.firstName)
            //   .ToList();

            //var result = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);
            //File.AppendAllText("../../../Datasets/users-sold-products.json", result);
            //return result;  
        }

        

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IMapper mapper = InitializeMapper();

            ICollection<Category> categories = context.Categories.Include(c => c.CategoryProducts).ThenInclude(cp => cp.Product)
                .ToList();

            ICollection<CategoryViewDto> categoryViewDtos = mapper.Map<ICollection<Category>, ICollection<CategoryViewDto>>(categories)
                .OrderByDescending(c => c.ProductsCount).ToList();

            string result = JsonConvert.SerializeObject(categoryViewDtos, JsonSettings());

            return result;
            //var categories = context.Categories
            //    .Select(x => new
            //    {
            //        category = x.Name,
            //        productsCount = x.CategoryProducts.Count,
            //        averagePrice = x.CategoryProducts.Select(p => p.Product.Price).DefaultIfEmpty(0).Average().ToString("f2"),
            //        totalRevenue = x.CategoryProducts.Select(p => p.Product.Price).Sum()
            //    })
            //    .OrderByDescending(x => x.productsCount)
            //    .ToList();

            //var result = JsonConvert.SerializeObject(categories, Formatting.Indented);
            //File.AppendAllText("./../../../categories-by-products.json", result);
            //return result;
        }

        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            //IMapper mapper = InitializeMapper();

            //ICollection<User> users = context.Users.Include(u => u.ProductsSold).Where(u => u.ProductsSold.Count > 0 && u.ProductsSold.Select(p => p.Buyer) != null).ToList();

            //ICollection<UserWithProductsViewDto> userWithProductsViewDtos = mapper.Map<ICollection<User>, ICollection<UserWithProductsViewDto>>(users);

            //var userWithCount = new { usersCount = userWithProductsViewDtos.Count(), users };
            var users = context.Users
                .Where(x => x.ProductsSold.Count() > 0)
                .OrderByDescending(x => x.ProductsSold.Count)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Count(),
                        products = x.ProductsSold.Select(p => new
                        {
                            name = p.Name,
                            price = p.Price.ToString("f2")
                        })
                    }
                })
                .ToList();

            var usersOutput = new { usersCount = users.Count, users };

            string result = JsonConvert.SerializeObject(usersOutput , JsonSettings());

            return result;
        }

        private static JsonSerializerSettings JsonSettings()
        {
            DefaultContractResolver defaultContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = defaultContractResolver
            };

            return jsonSerializerSettings;
        }

        private static IMapper InitializeMapper()
        {
            IConfigurationProvider configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            IMapper mapper = new Mapper(configuration);
            return mapper;
        }
    }
}