namespace Panda.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Panda.Data;
    using Panda.Data.Models;
    using Panda.Services.Contracts;
    using Panda.ViewModels.Packages;
    using Panda.ViewModels.UserModels;

    using static Panda.Common.GlobalConstants;

    public class PackagesService : IPackagesService
    {
        private readonly ApplicationDbContext dbContext;

        public PackagesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(PackageInputModel input)
        {
            var package = new Package
            {
                Description = input.Description,
                Weight = double.Parse(input.Weight),
                ShippingAddress = input.ShippingAddress,
                Status = Data.Enums.Status.Pending,
                EstimatedDelivery = DateTime.UtcNow.AddHours(2),
            };

            package.Recipient = this.dbContext.Users.FirstOrDefault(u => u.Username == input.RecipientName);

            await this.dbContext.AddAsync(package);
            await this.dbContext.SaveChangesAsync();
        }

        public ICollection<PackageViewModel> GetPendingPackages()
        {
            var pendeingPackages = this.dbContext.Packages
                .Where(p => p.Status == Data.Enums.Status.Pending)
                .Select(p => new PackageViewModel
                { 
                    Description = p.Description,
                    Id = p.Id,
                    ShippingAddress = p.ShippingAddress,
                    Weight = p.Weight,
                    RecipientName = p.Recipient.Username,
                })
                .ToList();

            return pendeingPackages;
        }

        public ICollection<PackageViewModel> GetDeliveredPackages()
        {
            var pendeingPackages = this.dbContext.Packages
                .Where(p => p.Status == Data.Enums.Status.Delivered)
                .Select(p => new PackageViewModel
                {
                    Description = p.Description,
                    Id = p.Id,
                    ShippingAddress = p.ShippingAddress,
                    Weight = p.Weight,
                    RecipientName = p.Recipient.Username,
                })
                .ToList();

            return pendeingPackages;
        }

        public ICollection<RecepientViewModel> GetRecepients()
        {
            var recepients = this.dbContext.Users
                 .Select(r => new RecepientViewModel
                 { 
                    RecipientName = r.Username,
                 })
                 .ToList();

            return recepients;
        }

        public async Task SetToDelivered(string id)
        {
            var package = this.dbContext.Packages.FirstOrDefault(p => p.Id == id);
            package.Status = Data.Enums.Status.Delivered;
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<string> PackageValidation(PackageInputModel input)
        {
            var errorList = new List<string>();

            if (string.IsNullOrWhiteSpace(input.Description) 
                || input.Description.Length > PackageDescriptionMaxLength 
                || input.Description.Length < PackageDescriptionMinLength)
            {
                errorList.Add(string.Format(InvalidDescription, PackageDescriptionMinLength, PackageDescriptionMaxLength));
            }

            if (!double.TryParse(input.Weight, out double _))
            {
                errorList.Add(InvalidWeight);
            }
            else if (double.Parse(input.Weight) < 0)
            {
                errorList.Add(InvalidWeight);
            }

            if (!this.dbContext.Users.Any(r => r.Username == input.RecipientName))
            {
                errorList.Add(InvalidRecipientName);
            }

            return errorList;
        }
    }
}
