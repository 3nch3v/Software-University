using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //var inpuUserstXml = File.ReadAllText(@"..\..\..\Datasets\users.xml");
            //var inputProductsXml = File.ReadAllText(@"..\..\..\Datasets\products.xml");
            //var inputCategoriesXml = File.ReadAllText(@"..\..\..\Datasets\categories.xml");
            //var importCategoryProductsXml = File.ReadAllText(@"..\..\..\Datasets\categories-products.xml");

            //ImportUsers(db, inpuUserstXml);
            //ImportProducts(db, inputProductsXml);

            var result = GetProductsInRange(db);
            Console.WriteLine(result);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
               .Products
               .Where(p => p.Price >= 500 && p.Price <= 1000)
               .Select(p => new ProductsExportDto()
               {
                   Name = p.Name,
                   Price = p.Price,
                   Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
               })
               .OrderBy(p => p.Price)
               .Take(10)
               .ToArray();

            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ProductsExportDto[]), new XmlRootAttribute("Products"));
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            serializer.Serialize(new StringWriter(sb), products, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            var reader = new StringReader(inputXml);
            XmlRootAttribute root = new XmlRootAttribute("CategoryProducts");
            XmlSerializer serializer = new XmlSerializer(typeof(CategoriesProductsInputDto[]), root);
            var categoriesProductsDtos = serializer.Deserialize(reader);

            var categoriesIds = context.Categories.Select(c => c.Id).ToList();
            var productsIds = context.Products.Select(p => p.Id).ToList();

            var categoriesProducts = mapper.Map<ICollection<CategoryProduct>>(categoriesProductsDtos)
                .Where(cp => categoriesIds.Contains(cp.CategoryId) && productsIds.Contains(cp.ProductId))
                .ToList();

            context.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeMapper();
            XmlRootAttribute root = new XmlRootAttribute("Categories");
            var reader = new StringReader(inputXml);
            XmlSerializer serializer = new XmlSerializer(typeof(CategoriesInputDto[]), root);
            var dtoCategories =  serializer.Deserialize(reader);

            var categories = mapper.Map<ICollection<Category>>(dtoCategories)
                .Where(c => c.Name != null).ToList();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            XmlRootAttribute root = new XmlRootAttribute("Products");
            var textReader = new StringReader(inputXml);
            XmlSerializer serializer = new XmlSerializer(typeof(ProductsInputDto[]), root);
            var dtoProducts = serializer.Deserialize(textReader);

            var products = mapper.Map<ICollection<Product>>(dtoProducts);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            XmlRootAttribute root = new XmlRootAttribute("Users");
            XmlSerializer serializer = new XmlSerializer(typeof(UsersInputDto[]), root);
            TextReader reader = new StringReader(inputXml);
            var dtoUsers = serializer.Deserialize(reader);

           var users = mapper.Map<ICollection<User>>(dtoUsers);

           context.AddRange(users);
           context.SaveChanges();

            return $"Successfully imported {users.Count}"; ;
        }

        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}