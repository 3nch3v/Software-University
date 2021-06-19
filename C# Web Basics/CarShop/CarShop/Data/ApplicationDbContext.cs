namespace CarShop.Data
{
    using Microsoft.EntityFrameworkCore;

    using CarShop.Data.Models;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Issue> Issues { get; set; }

        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }
    }
}
