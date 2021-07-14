namespace Eventures.Data.Models
{
    using System;

    public class Event
    {
        public Event()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Place { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int Tickets { get; set; }

        public double TicketPrice { get; set; }
    }
}