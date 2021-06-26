namespace Panda.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Panda.Data;
    using Panda.Data.Models;
    using Panda.Services.Contracts;
    using Panda.ViewModels.Receipts;

    public class ReceiptsService : IReceiptsService
    {
        private readonly ApplicationDbContext dbContext;

        public ReceiptsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateReceiptAsync(string id)
        {
            var package = this.dbContext.Packages.FirstOrDefault(p => p.Id == id);
            var fee = package.Weight * 2.67;

            var receipt = new Receipt
            {
                IssuedOn = DateTime.UtcNow,
                PackageId = package.Id,
                RecipientId = package.RecipientId,
                Fee = (decimal)fee,
            };

            await this.dbContext.AddAsync(receipt);
            await this.dbContext.SaveChangesAsync();
        }

        public ICollection<ReceiptViewModel> GetAll()
        {
            var receipts = this.dbContext.Receipts
                .Select(r => new ReceiptViewModel
                {
                    Id = r.Id,
                    Fee = r.Fee,
                    IssuedOn = r.IssuedOn.ToString("s"),
                    RecipientName = r.Recipient.Username,
                })
                .ToList();

            return receipts;
        }
    }
}
