using System;
using Microsoft.EntityFrameworkCore;
using Warehouse.Models.CustomerModels;
using Warehouse.Models.ProductModels;

namespace Warehouse.Data
{
    public class WHContext : DbContext
    {
        public WHContext() { }

        public WHContext(DbContextOptions options)
            :base(options)  { }


        public DbSet<Collection> Collections { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<CountryOfOrigin> CountriesOfOrigin { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<SizeColorProduct> SizesColorsProducts { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<InvoiceAddress> InvoicesAddresses { get; set; }

        public DbSet<ShippingAddress> ShippingAddresses { get; set; }

   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SizeColorProduct>()
                .HasKey(k => new
                {
                    k.ProductId,
                    k.SizeId,
                    k.ColorId
                });

            modelBuilder.Entity<Product>()
                .Property(p => p.Date)
                .HasDefaultValue(DateTime.UtcNow);

        }
    }
}
