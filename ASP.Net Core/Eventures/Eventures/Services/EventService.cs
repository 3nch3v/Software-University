namespace Eventures.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Eventures.ViewModels;
    using Eventures.Data.Models;
    using Eventures.Data;

    public class EventService : IEventService
    {
        private readonly EventuresDbContext dbContext;

        public EventService(EventuresDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(EventInputModel input)
        {
            Event newEvent = new()
            {
                Name = input.Name,
                Place = input.Place,
                Start = input.Start,
                End = input.End,
                Tickets = input.Tickets,
                TicketPrice = input.TicketPrice,
            };

            await this.dbContext.Events.AddAsync(newEvent);
            await this.dbContext.SaveChangesAsync();
        }

        public ICollection<EventViewModel> GetAll()
        {
            var events = this.dbContext.Events
                .Select(e => new EventViewModel
                { 
                    Name = e.Name,
                    Start = e.Start.ToString("dd-MMM-yy hh:mm:ss"),
                    End = e.End.ToString("dd-MMM-yy hh:mm:ss"),
                    Place = e.Place,
                })
                .ToList();

            return events;
        }
    }
}
