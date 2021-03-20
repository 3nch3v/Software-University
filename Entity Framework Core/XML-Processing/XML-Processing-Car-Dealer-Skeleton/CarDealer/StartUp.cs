using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.Data;
using CarDealer.ImportModels;
using CarDealer.Models;

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

            var inputCarsXml = File.ReadAllText(@"..\..\..\Datasets\cars.xml");

            var result = ImportCars(dbContext, inputCarsXml);
            Console.WriteLine(result);
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string root = "Cars";
            var dtoCars = XmlConverter.Deserializer<CarDTO>(inputXml, root);
          
            var cars = new List<Car>();
            var allparts = context.Parts.Select(x => x.Id).ToList();

            foreach (var car in dtoCars)
            {
                var distinctedParts = car.PartsIds.Select(x => x.Id).Distinct();
                var parts = distinctedParts.Intersect(allparts);

                var currCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TraveledDistance
                };

                foreach (var part in parts)
                {
                    var partCar = new PartCar
                    {
                        PartId = part
                    };

                    currCar.PartCars.Add(partCar);
                }

                cars.Add(currCar);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitializeMapper();
            XmlRootAttribute root = new XmlRootAttribute("Parts");
            TextReader reader = new StringReader(inputXml);
            XmlSerializer serializer = new XmlSerializer(typeof(PartsDTO[]), root);
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
            XmlSerializer serializer = new XmlSerializer(typeof(SupplierDTO[]), root);
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