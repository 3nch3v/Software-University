using System;

namespace Eventures.ViewModels
{
    public class EventInputModel
    {
        public string Name { get; set; }

        public string Place { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int Tickets { get; set; }

        public double TicketPrice { get; set; }
    }
}
