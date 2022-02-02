using ProductShop.Data;
using ProductShop.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System;
using ProductShop.Dtos.Import;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using ProductShop.Dtos.Export.User;
using ProductShop.Dtos.Export.Product;
using ProductShop.DTO.Category;
using AutoMapper.QueryableExtensions;

namespace ProductShop
{
    public class StartUp
    {
        public static object GenerateXmlSerializer { get; private set; }

        public static void Main(string[] args)
        {
            ProductShopContext dbContext = new ProductShopContext();

            //dbContext.Database.EnsureCreated();
            //RebuildDatabase(dbContext);
            //Console.WriteLine(ImportUsers(dbContext , File.ReadAllText("../../../Datasets/users.xml")));
            //Console.WriteLine(ImportProducts(dbContext , File.ReadAllText("../../../Datasets/products.xml")));
            //Console.WriteLine(ImportCategories(dbContext , File.ReadAllText("../../../Datasets/categories.xml")));
            //Console.WriteLine(ImportCategoryProducts(dbContext , File.ReadAllText("../../../Datasets/categories-products.xml")));
            //Console.WriteLine(GetProductsInRange(dbContext));
            //Console.WriteLine(GetSoldProducts(dbContext));
            //Console.WriteLine(GetCategoriesByProductsCount(dbContext));
            Console.WriteLine(GetUsersWithProducts(dbContext));

        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        => Import<User, UserImportDto>(context, inputXml, "Users");

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
            => Import<Product, ProductImportDto>(context, inputXml, "Products");

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
            => Import<Category, CategoryImportDto>(context, inputXml, "Categories");

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeMapper();

            var serializer = new XmlSerializer(typeof(CategoryProductImportDto[]), new XmlRootAttribute("CategoryProducts"));

            CategoryProductImportDto[] inputDtos = serializer.Deserialize(new StringReader(inputXml)) as CategoryProductImportDto[];

            ICollection<CategoryProduct> input = mapper.Map<ICollection<CategoryProductImportDto>, ICollection<CategoryProduct>>(inputDtos)
                .Where(x => context.Categories.ToList().Select(a => a.Id).Contains(x.CategoryId) && 
                context.Products.ToList().Select(a => a.Id).Contains(x.ProductId)).ToList();

            context.CategoryProducts.AddRange(input);

            context.SaveChanges();

            return $"Successfully imported {input.Count}";
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var products = context.Products.Include(p => p.Buyer).ToArray().Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new GetProductsInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price.ToString(),
                    Buyer = p.Buyer != null ? $"{p.Buyer.FirstName} {p.Buyer.LastName}" : null
                }).OrderBy(p => p.Price).Take(10).ToArray();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty,String.Empty);
            var serializer = new XmlSerializer(typeof(GetProductsInRangeDto[]), new XmlRootAttribute("Products"));
            using (var stringWriter = new StringWriter(sb))
            {
                serializer.Serialize(stringWriter, products , namespaces);
            }
            return sb.ToString();
        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var users = context.Users.Where(u => u.ProductsSold.Count > 0)
                .Select(u => new UserSoldProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = new SoldProductsDto
                    {
                        Product = u.ProductsSold
                        .Select(p => new ProductNamePriceDto()
                        {
                            Name = p.Name,
                            Price = p.Price.ToString()
                        }).ToArray()
                    }
                    
                }).OrderBy(u => u.LastName).ThenBy(u => u.FirstName).Take(5).ToArray();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(String.Empty, String.Empty);

            var serializer = new XmlSerializer(typeof(UserSoldProductsDto[]), new XmlRootAttribute("Users"));

            using (var stringWriter = new StringWriter(sb))
            {
                serializer.Serialize(stringWriter, users, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            IMapper mapper = InitializeMapper();

            CategoryDto[] categories = context.Categories.ProjectTo<CategoryDto>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.ProductsCount).ThenBy(c => c.TotalRevenue).ToArray();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(String.Empty, String.Empty);

            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));

            using (var stringWriter = new StringWriter(sb))
            {
                serializer.Serialize(stringWriter, categories, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var users = context.Users.Where(u => u.ProductsSold.Count > 0).Select(u => new UserWithProductsDto()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Age = u.Age,
                SoldProducts = new ProductsCountDto()
                {
                    Count = u.ProductsSold.Count,
                    Products = new ProductsDto()
                    {
                        Product = u.ProductsSold.Select(p => new ProductNamePriceDto()
                        {
                            Name = p.Name,
                            Price = p.Price.ToString()
                        }).OrderByDescending(p => p.Price).ToArray()
                    }
                }
            }).OrderByDescending(u => u.SoldProducts.Count);

            UserCountDto userCountDto = new UserCountDto()
            {
                Count = users.Count(),
                Users = new UsersDto()
                {
                    User = users.ToArray()
                }
            };

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(String.Empty, String.Empty);

            var serializer = new XmlSerializer(typeof(UserCountDto), new XmlRootAttribute("Users"));

            using (var stringWriter = new StringWriter(sb))
            {
                serializer.Serialize(stringWriter, userCountDto, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string Import<T , DTO>(ProductShopContext context, string inputXml , string root)
        {
            IMapper mapper = InitializeMapper();

            var serializer = new XmlSerializer(typeof(DTO[]), new XmlRootAttribute(root));

            DTO[] inputDtos = serializer.Deserialize(new StringReader(inputXml)) as DTO[];

            ICollection<T> input = mapper.Map<ICollection<DTO>, ICollection<T>>(inputDtos);
            //input =  input.Where(x => !context.Products.Any(p => p.Id == x.Id)).ToList();

            if (root == "Users")
            {
                context.Users.AddRange((ICollection<User>)input);
            }
            else if (root == "Products")
            {
                context.Products.AddRange((ICollection<Product>)input);
            }
            else if (root == "Categories")
            {
                context.Categories.AddRange((ICollection<Category>)input);
            }

            context.SaveChanges();

            return $"Successfully imported {input.Count}";
        }

        public static IMapper InitializeMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            IMapper mapper = new Mapper(configuration);

            return mapper;
        }

        public static void RebuildDatabase(ProductShopContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}