using SharedTrip.Data;
using SharedTrip.Services.Contracts;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext dbContext;

        public TripsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(TripInputModel input)
        {
            var trip = new Trip
            {
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                Description = input.Description,
                DepartureTime = DateTime.ParseExact(input.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = input.ImagePath,
                Seats = input.Seats,
            };

            await this.dbContext.Trips.AddAsync(trip);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> AddAddUserToTrip(string tripId, string userId)
        {
            var isTripAlreadyBooked = this.dbContext.UserTrips.Any(ut => ut.TripId == tripId && ut.UserId == userId);
            var tripSeats = this.dbContext.Trips.FirstOrDefault(t => t.Id == tripId).Seats;
            var bookedSeats = this.dbContext.UserTrips.Where(ut => ut.TripId == tripId).Count();

            if (isTripAlreadyBooked 
                || tripSeats - bookedSeats <= 0)
            {
                return false;
            }

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId,
            };

            await this.dbContext.UserTrips.AddAsync(userTrip);
            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public IEnumerable<AllTripsViewmodel> GetAll()
        {
            var trips = this.dbContext.Trips
                .Select(t => new AllTripsViewmodel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    EndPoint = t.EndPoint,
                    Seats = t.Seats - t.UserTrips.Count(),
                })
                .ToList();

            return trips;
        }

        public TripViewModel GetDetails(string id)
        {
            var trip = this.dbContext.Trips
                .Where(t => t.Id == id)
                .Select(t => new TripViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    EndPoint = t.EndPoint,
                    Seats = t.Seats - t.UserTrips.Count(),
                    Description = t.Description,
                    ImagePath = t.ImagePath,
                })
                .FirstOrDefault();

            return trip;
        }
    }
}
