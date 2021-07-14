namespace Eventures.Infrastructure
{
    using System;
    using System.Linq;
    using Eventures.Data;
    using Eventures.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<EventuresDbContext>();

            data.Database.Migrate();

            SeedEvents(data);

            return app;
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
