using System;

namespace SharedTrip.ViewModels.TripModels
{
    public class BaseTripViewModel
    {
        public string Id { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public int Seats { get; set; }

        public int ReservedSeats { get; set; }

        public int AvailableSeats => Seats - ReservedSeats;
    }
}
