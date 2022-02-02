using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;

namespace CarDealer
{
    using AutoMapper.QueryableExtensions;
    using CarDealer.Data;
    using CarDealer.DTO.Car;
    using CarDealer.DTO.Part;
    using CarDealer.DTO.Supplier;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext dbContext = new CarDealerContext();

            //dbContext.Database.EnsureCreated();
            //Console.WriteLine(ImportSuppliers(dbContext, File.ReadAllText("../../../Datasets/suppliers.json")));
            //Console.WriteLine(ImportParts(dbContext, File.ReadAllText("../../../Datasets/parts.json")));
            //Console.WriteLine(ImportCars(dbContext, File.ReadAllText("../../../Datasets/cars.json")));
            //Console.WriteLine(ImportCustomers(dbContext, File.ReadAllText("../../../Datasets/customers.json")));
            //Console.WriteLine(ImportSales(dbContext, File.ReadAllText("../../../Datasets/sales.json")));
            //Console.WriteLine(GetOrderedCustomers(dbContext));
            //Console.WriteLine(GetCarsFromMakeToyota(dbContext));
            //Console.WriteLine(GetLocalSuppliers(dbContext));
            Console.WriteLine(GetCarsWithTheirListOfParts(dbContext));
        }

        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            ICollection<LocalSupplierDto> suppliers = JsonConvert.DeserializeObject<ICollection<LocalSupplierDto>>(inputJson);

            context.AddRange(suppliers);

            context.SaveChanges();

            string result = $"Successfully imported {suppliers.Count}.";

            return result;
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            ICollection<Part> parts = JsonConvert.DeserializeObject<ICollection<Part>>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId)).ToList();

            context.AddRange(parts);

            context.SaveChanges();

            string result = $"Successfully imported {parts.Count}.";

            return result;
        }

        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ICollection<CarInputDto> carDtos = JsonConvert.DeserializeObject<ICollection<CarInputDto>>(inputJson);

            List<Car> cars = new List<Car>();
            List<PartCar> carParts = new List<PartCar>();

            foreach (var carDto in carDtos)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };
                foreach (var partId in carDto.PartsId.Distinct())
                {
                    var part = new PartCar()
                    {
                        PartId = partId,
                        Car = car
                    };
                    carParts.Add(part);
                }
                cars.Add(car);
            }

            context.AddRange(cars);
            context.AddRange(carParts);

            context.SaveChanges();

            string result = $"Successfully imported {cars.Count}.";

            return result;
        }

        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            ICollection<Customer> customers = JsonConvert.DeserializeObject<ICollection<Customer>>(inputJson);

            context.AddRange(customers);

            context.SaveChanges();

            string result = $"Successfully imported {customers.Count}.";

            return result;
        }


        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            ICollection<Sale> sales = JsonConvert.DeserializeObject<ICollection<Sale>>(inputJson);

            context.AddRange(sales);

            context.SaveChanges();

            string result = $"Successfully imported {sales.Count}.";

            return result;
        }

        //14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            IMapper mapper = InitializeMapper();

            var customers = context.Customers.OrderBy(c => c.BirthDate).ThenBy(c => c.IsYoungDriver)
                .Select(c => new { c.Name, BirthDate = c.BirthDate.ToString("dd/MM/yyyy") , c.IsYoungDriver });
                //.ProjectTo<OrderedCustomerDto>(mapper.ConfigurationProvider).ToList();

            string result = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return result;
        }

        //15. Export Cars From Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            IMapper mapper = InitializeMapper();

            var cars = context.Cars.Where(c => c.Make == "Toyota").OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance).ProjectTo<CarFromMakeDto>(mapper.ConfigurationProvider).ToList();

            string result = JsonConvert.SerializeObject(cars , Formatting.Indented);

            return result;
        }

        //16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            IMapper mapper = InitializeMapper();

            var suppliers = context.Suppliers.Where(s => s.IsImporter == false)
                .ProjectTo<LocalSupplierDto>(mapper.ConfigurationProvider).ToList();

            string result = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return result;
        }

        //17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            IMapper mapper = InitializeMapper();

           var cars = context.Cars.Include(c => c.PartCars).ThenInclude(p => p.Part).ToList();

            var carDto = mapper.Map<ICollection<Car>, ICollection<CarMakeModelTravelledDto>>(cars);
            var partDto = mapper.Map<ICollection<Car>, ICollection<CarPartsDto>>(cars);
            var carWithPartsDto = new CarWithPartsDto();
            foreach (var car in carDto)
            {
                foreach (var part in partDto)
                {
                    carWithPartsDto.car = car;
                    carWithPartsDto.parts = (ICollection<PartNamePriceDto>)part;
                }
            }
            string result = JsonConvert.SerializeObject(cars, Formatting.Indented);
            //File.WriteAllText("../../../Datasets/car-list.json" , result);
            return result;//File.ReadAllText("../../../Datasets/car-list.json");
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
                cfg.AddProfile<CarDealerProfile>();
            });

            IMapper mapper = new Mapper(configuration);
            return mapper;
        }
    }
}