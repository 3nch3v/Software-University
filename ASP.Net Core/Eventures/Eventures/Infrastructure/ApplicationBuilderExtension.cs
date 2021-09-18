namespace Eventures.Infrastructure
{
    using System;
    using System.Linq;
    using Eventures.Data;
    using Eventures.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            //var roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            //var userManager = app.ApplicationServices.GetRequiredService<UserManager<ApplicationUser>>();
            var data = scopedServices.ServiceProvider.GetService<EventuresDbContext>();

            data.Database.Migrate();

            SeedEvents(data);
            //SeedUsers(data, roleManager, userManager);

            return app;
        }

        private static void SeedUsers(
            EventuresDbContext data, 
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            if (data.ApplicationUsers.Any())
            {
                return;
            }

            roleManager.CreateAsync(new IdentityRole("ADMIN"));
            roleManager.CreateAsync(new IdentityRole("USER"));

            var admin = new ApplicationUser
            {
                Id = "fa10629e-d365-4f48-823a-4063b34e4469",
                FirstName = "Ivan",
                LastName = "Enchev",
                UniqueCitizenNumber = "12313-434-34-234",
                UserName = "ivan",
                NormalizedEmail = "IVAN",
                Email = "ivan.enchev@gmx.de",
                NormalizedUserName = "IVAN.ENCHEV@GMX.DE",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAECJ8nmayJgeOoAZgq1q5Iy4jYMEXdxwZTzp1qudQ6m9W1vuzbRLJsq7YlvwDuo8K7w==",
                SecurityStamp = "QVFFCIMEC37GKWG2XBFYEMAYSMV5KNFR",
                ConcurrencyStamp = "1b256519-210c-4731-8884-badfd81f9720",
                PhoneNumber = "123456787",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
            };

            userManager.CreateAsync(admin);
            userManager.AddToRoleAsync(admin, "ADMIN");
        }

        private static void SeedEvents(EventuresDbContext data)
        {
            if (data.Events.Any())
            {
                return;
            }

            data.Events.AddRange(new[]
            {
                new Event { Name = "2Pac", Start = new DateTime(21, 01, 22, 15, 22, 0 ), End = new DateTime(22, 11, 23, 15, 12, 0 ), Place = "", Tickets = 1000, TicketPrice = 2.50 },
                new Event { Name = "Eminem", Start = new DateTime(20, 01, 22, 15, 22, 0 ), End = new DateTime(22, 11, 23, 15, 12, 0 ), Place = "", Tickets = 1000, TicketPrice = 2.50 },
                new Event { Name = "100 Kila", Start = new DateTime(19, 01, 22, 17, 22, 0 ), End = new DateTime(22, 11, 23, 15, 12, 0 ), Place = "", Tickets = 1000, TicketPrice = 2.50 },
                new Event { Name = "Bushido", Start = new DateTime(21, 10, 25, 12, 26, 0 ), End = new DateTime(22, 11, 23, 15, 12, 0 ), Place = "", Tickets = 1000, TicketPrice = 2.50 },
                new Event { Name = "Ghetto", Start = new DateTime(21, 08, 24, 13, 23, 0 ), End = new DateTime(22, 11, 23, 15, 12, 0 ), Place = "", Tickets = 1000, TicketPrice = 2.50 },
                new Event { Name = "Capital Bra", Start = new DateTime(21, 07, 21, 16, 29, 0 ), End = new DateTime(22, 11, 23, 15, 12, 0 ), Place = "", Tickets = 1000, TicketPrice = 2.50 },
            });

            data.SaveChanges();
        }
    }
}
