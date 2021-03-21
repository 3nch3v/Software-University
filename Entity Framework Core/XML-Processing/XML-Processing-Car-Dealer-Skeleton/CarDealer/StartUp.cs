using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.Data;
using CarDealer.ExportModels;
using CarDealer.ImportModels;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var dbContext = new CarDealerContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //var inputSuppliersXml = File.ReadAllText(@"..\..\..\Datasets\suppliers.xml");
            //ImportSuppliers(dbContext, inputSuppliersXml);

            //var inputPartsXml = File.ReadAllText(@"..\..\..\Datasets\parts.xml");
            //ImportParts(dbContext, inputPartsXml);

            //var inputCarsXml = File.ReadAllText(@"..\..\..\Datasets\cars.xml");
            //ImportCars(dbContext, inputCarsXml);

            //var inputCustomersXml = File.ReadAllText(@"..\..\..\Datasets\customers.xml");
            //ImportCustomers(dbContext, inputCustomersXml);

            //var inputSalesXml = File.ReadAllText(@"..\..\..\Datasets\sales.xml");

            var result = GetSalesWithAppliedDiscount(dbContext);
            Console.WriteLine(result);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new SaleExportModel
                {
                    CarInfo = new CarInfoExportModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },

                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(x => x.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(x => x.Part.Price) -
                                        (s.Car.PartCars.Sum(x => x.Part.Price) * s.Discount / 100)
                })
                .ToArray();

            //StringBuilder sb = new StringBuilder();
            //XmlSerializer serializer = new XmlSerializer(typeof(SaleExportModel[]), new XmlRootAttribute("sales"));
            //serializer.Serialize(new StringWriter(sb), sales, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
            //return sb.ToString().TrimEnd();

            var result = XmlConverter.Serialize(sales, "sales");
            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var salesByCustomer = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new CustomerWithTotalSalesExportModel
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(CustomerWithTotalSalesExportModel[]), new XmlRootAttribute("customers"));
            serializer.Serialize(new StringWriter(sb), salesByCustomer, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(c => new CarsWithPartsExportModel 
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(p => new PartExportModel
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(CarsWithPartsExportModel[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), carsWithParts, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new SupplierExportModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(SupplierExportModel[]), new XmlRootAttribute("suppliers"));
            serializer.Serialize(new StringWriter(sb), suppliers, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmwCars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new BMWCarsExportModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(BMWCarsExportModel[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), bmwCars, new XmlSerializerNamespaces(new[] {XmlQualifiedName.Empty}));

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .Select(c => new CarsWithTravelledDistanceExportModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();
            
            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(CarsWithTravelledDistanceExportModel[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), cars, new XmlSerializerNamespaces(new[] {XmlQualifiedName.Empty} ));

            return sb.ToString().TrimEnd();
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            InitializeMapper();
            var carsIds = context.Cars.Select(x => x.Id).ToList();
            XmlSerializer serializer = new XmlSerializer(typeof(SalesImportDto[]), new XmlRootAttribute("Sales"));
            var salesDto = serializer.Deserialize(new StringReader(inputXml));
            var sales = mapper.Map<ICollection<Sale>>(salesDto)
                .Where(c => carsIds.Contains(c.CarId))
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            XmlSerializer serializer = new XmlSerializer(typeof(CustomersImportDto[]), new XmlRootAttribute("Customers"));
            var customersDto = serializer.Deserialize(new StringReader(inputXml));
            var customers = mapper.Map<ICollection<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string root = "Cars";
            var dtoCars = XmlConverter.Deserializer<CarImportDto>(inputXml, root);

            //var cars = new List<Car>();
            //var allparts = context.Parts.Select(x => x.Id).ToList();

            //foreach (var car in dtoCars)
            //{
            //    var distinctedParts = car.PartsIds.Select(x => x.Id).Distinct();
            //    var parts = distinctedParts.Intersect(allparts);
            //    var currCar = new Car
            //    {
            //        Make = car.Make,
            //        Model = car.Model,
            //        TravelledDistance = car.TraveledDistance
            //    };

            //    foreach (var part in parts)
            //    {
            //        var partCar = new PartCar
            //        {
            //            PartId = part
            //        };

            //        currCar.PartCars.Add(partCar);
            //    }
            //    cars.Add(currCar);
            //}

            var cars = dtoCars
                .Select(c => new Car
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TraveledDistance,
                    PartCars = c.PartsIds
                        .Select(x => x.Id)
                        .Distinct()
                        .Select(p => new PartCar
                        {
                            PartId = p
                        })
                        .ToList()
                })
                .ToList(); 

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitializeMapper();
            XmlRootAttribute root = new XmlRootAttribute("Parts");
            TextReader reader = new StringReader(inputXml);
            XmlSerializer serializer = new XmlSerializer(typeof(PartsImportDto[]), root);
            var partsDTO = serializer.Deserialize(reader);

            var suppliersIds = context.Suppliers
                .Select(s => s.Id)
                .ToList();

            var parts = mapper.Map<ICollection<Part>>(partsDTO)
                .Where(p => suppliersIds.Contains(p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            XmlRootAttribute root = new XmlRootAttribute("Suppliers");
            XmlSerializer serializer = new XmlSerializer(typeof(SupplierImportDto[]), root);
            TextReader reader = new StringReader(inputXml);
            var suppliersDTO = serializer.Deserialize(reader);

            var suppliers = mapper.Map<ICollection<Supplier>>(suppliersDTO);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
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