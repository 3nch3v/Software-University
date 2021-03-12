using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

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

        }
    }
}
