using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;


namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayersStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(k => new {k.GameId, k.PlayerId});


            modelBuilder.Entity<Team>(x =>
            {
                x.HasOne(p => p.PrimaryKitColor)
                    .WithMany(p => p.PrimaryKitTeams)
                    .HasForeignKey(p => p.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                x.HasOne(s => s.SecondaryKitColor)
                    .WithMany(s => s.SecondaryKitTeams)
                    .HasForeignKey(s => s.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Game>(x =>
            {
                x.HasOne(h => h.HomeTeam)
                    .WithMany(h => h.HomeGames)
                    .HasForeignKey(h => h.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                x.HasOne(a => a.AwayTeam)
                    .WithMany(a => a.AwayGames)
                    .HasForeignKey(a => a.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
