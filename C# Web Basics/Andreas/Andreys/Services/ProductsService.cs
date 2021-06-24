namespace Andreys.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Andreys.Data;
    using Andreys.Data.Enums;
    using Andreys.Data.Models;
    using Andreys.Services.Contracts;
    using Andreys.ViewModels.ProductModels;
    using static Andreys.Common.GlobalConstants;

    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext dbContext;

        public ProductsService(AndreysDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddProductAsync(ProductInputModel input)
        {
            var product = new Product
            {
                Name = input.Name,
                Description = input.Description,
                ImageUrl = input.ImageUrl,
                Price = decimal.Parse(input.Price),
                Category = Enum.Parse<Category>(input.Category),
                Gender = Enum.Parse<Gender>(input.Gender),
            };

            await this.dbContext.Products.AddAsync(product);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = this.dbContext.Products.FirstOrDefault(p => p.Id == id);

            this.dbContext.Products.Remove(product);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var products = this.dbContext.Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Price = p.Price
                })
                .ToList();

            return products;
        }

        public SigleProductViewModel GetById(int id)
        {
            var product = this.dbContext.Products
                .Select(p => new SigleProductViewModel
                {
                    Id = p.Id,
                    Category = p.Category.ToString(),
                    Description = p.Description,
                    Gender = p.Gender.ToString(),
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Price = p.Price
                })
                .FirstOrDefault(p => p.Id == id);

            return product;
        }

        public IEnumerable<string> InputValidation(ProductInputModel input)
        {
            var errorList = new List<string>();

            if (string.IsNullOrWhiteSpace(input.Name)
                || input.Name.Length > PrductNameMaxLength
                || input.Name.Length < PrductNameMinLength)
            {
                errorList.Add(string.Format(InvalidProductName, PrductNameMaxLength, PrductNameMinLength));
            }

            if (string.IsNullOrWhiteSpace(input.Name)
               || input.Description.Length > DescriptionMaxLength)
            {
                errorList.Add(string.Format(InvalidDescription, DescriptionMaxLength));
            }

            if (input.Description.Length > UrlMaxLength)
            {
                errorList.Add(InvalidUrl);
            }

            if (!Enum.TryParse<Category>(input.Category, true, out var category))
            {
                errorList.Add(InvalidCategory);
            }

            if (!Enum.TryParse<Gender>(input.Gender, true, out var gender))
            {
                errorList.Add(InvalidGender);
            }

            if (input.Price == null || !decimal.TryParse(input.Price, out decimal price))
            {
                errorList.Add(InvalidPrice);
            }

            return errorList;
        }

        public bool IsExisting(int id)
        {
            var product = this.dbContext.Products.FirstOrDefault(p => p.Id == id);

            return product != null;
        }
    }
}
