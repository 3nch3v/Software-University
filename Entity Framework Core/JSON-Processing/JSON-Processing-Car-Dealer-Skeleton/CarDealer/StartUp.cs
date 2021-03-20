using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //var inputJsonSuppliers = File.ReadAllText(@"..\..\..\Datasets\suppliers.json");
            //var inputJsonParts = File.ReadAllText(@"..\..\..\Datasets\parts.json");
            var inputJsonCars = File.ReadAllText(@"..\..\..\Datasets\cars.json");
            //var inputJsonCustomers = File.ReadAllText(@"..\..\..\Datasets\customers.json");
            //var inputJsonSales = File.ReadAllText(@"..\..\..\Datasets\sales.json");

            //string resultSuppliers = ImportSuppliers(db, inputJsonSuppliers);
            //Console.WriteLine(resultSuppliers);

            //string resultParts = ImportParts(db, inputJsonParts);
            //Console.WriteLine(resultParts);

            string resultCars = ImportCars(db, inputJsonCars);
            Console.WriteLine(resultCars);

            //string resultCustomers = ImportCustomers(db, inputJsonCustomers);
            //Console.WriteLine(resultCustomers);

            //string resultSales = ImportSales(db, inputJsonSales);
            //Console.WriteLine(resultSales);

            //Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance,
                    },

                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("f2"),
                    price = s.Car.PartCars.Sum(x => x.Part.Price).ToString("f2"),
                    priceWithDiscount = (s.Car.PartCars.Sum(x => x.Part.Price) - (s.Car.PartCars.Sum(x => x.Part.Price) * s.Discount / 100)).ToString("f2")
                })
                .Take(10)
                .ToList();

            string jsonOutput = JsonConvert.SerializeObject(sales, Formatting.Indented);
            return jsonOutput;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            string jsonOutput = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return jsonOutput;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new {c.Make,
                    c.Model,
                    c.TravelledDistance,
                    },

                    parts = c.PartCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("f2")
                    })
                })
                .ToList();

            string jsonOutput = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return jsonOutput;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            string jsonOutput = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return jsonOutput;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToList();

            string jsonOutput = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
            return jsonOutput;
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        { 
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            string jsonOutput = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return jsonOutput;
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeMapper();
            var dtoSales = JsonConvert.DeserializeObject<ICollection<SalesInputmodel>>(inputJson);
            var sales = mapper.Map<ICollection<Sale>>(dtoSales);

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var dtoCutomers = JsonConvert.DeserializeObject<ICollection<CustomerInputModel>>(inputJson);
            var customers = mapper.Map<ICollection<Customer>>(dtoCutomers);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var dtoCars = JsonConvert.DeserializeObject<ICollection<CarInputModel>>(inputJson);

            var cars = new List<Car>();

            foreach (var car in dtoCars)
            {
                var currCar = new Car
                              {
                                  Make = car.Make,
                                  Model = car.Model,
                                  TravelledDistance = car.TravelledDistance,
                              };

                foreach (var partId in car?.PartsId.Distinct())
                {
                    currCar.PartCars.Add(new PartCar
                                         {
                                             PartId = partId
                                         });
                }

                cars.Add(currCar);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var dtoParts = JsonConvert.DeserializeObject<ICollection<PartsImputModel>>(inputJson);

            var suppliersIds = context.Suppliers.Select(x => x.Id).ToList();

            var parts = mapper.Map<ICollection<Part>>(dtoParts)
                .Where(x => suppliersIds.Contains(x.SupplierId)).ToList();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var dtoSuppliers = JsonConvert.DeserializeObject<ICollection<SupplierInputModel>>(inputJson);

            var suppliers = mapper.Map<ICollection<Supplier>>(dtoSuppliers);
            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}