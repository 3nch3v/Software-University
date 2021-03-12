
using Microsoft.EntityFrameworkCore;
using WH.Models;

namespace WH.Data
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
    }
}
