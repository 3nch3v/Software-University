using System;
using Microsoft.EntityFrameworkCore;
using Warehouse.Models.CustomerModels;
using Warehouse.Models.EmployeeModels;
using Warehouse.Models.OrderModels;
using Warehouse.Models.ProductModels;
using Warehouse.Models.WarehouseModels;

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

        //-----

        public DbSet<Customer> Customers { get; set; }

        public DbSet<InvoiceAddress> InvoicesAddresses { get; set; }

        public DbSet<ShippingAddress> ShippingAddresses { get; set; }

        //-----

        public DbSet<Order> Orders { get; set; }

        //-----

        public DbSet<Box> Boxes { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Position> Positions { get; set; }

        //public DbSet<PickUpList> PickUpLists { get; set; }

        public DbSet<TheWareHouse> WareHouses { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        //-----

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


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
