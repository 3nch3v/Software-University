using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Services.Contracts;
using SharedTrip.ViewModels.TripModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static SharedTrip.Common.GlobalConstants;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext dbContext;

        public TripsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(TripInputModel input)
        {
            var trip = new Trip
            {
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                Description = input.Description,
                ImagePath = input.ImagePath,
                Seats = int.Parse(input.Seats),
                DepartureTime = DateTime.Parse(input.DepartureTime),
            };

            await this.dbContext.Trips.AddAsync(trip);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddUserToTripAsync(string tripId, string userId)
        {
            var trip = this.dbContext.Trips.FirstOrDefault(t => t.Id == tripId);
            var reservedSeats = GetReservedSeats(tripId);

            if (trip != null && trip.Seats - reservedSeats > 0)
            {
                var userTrip = new UserTrip
                {
                    TripId = tripId,
                    UserId = userId,
                };

                await this.dbContext.UsersTrips.AddAsync(userTrip);
                await this.dbContext.SaveChangesAsync();
            }      
        }

        public IEnumerable<TripViewmodel> All()
        {
            var trips = this.dbContext.Trips
                .Select(t => new TripViewmodel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime,
                    Seats = t.Seats,
                })
                .ToList();

            foreach (var trip in trips)
            {
                trip.ReservedSeats = GetReservedSeats(trip.Id);
            }

            return trips;
        }

        public TripDetailsViewModel GetById(string id)
        {
            var trip = this.dbContext.Trips
                .Select(t => new TripDetailsViewModel
                { 
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint =t.EndPoint,
                    DepartureTime = t.DepartureTime,
                    Description = t.Description,
                    ImagePath = t.ImagePath,
                    Seats = t.Seats,
                  
                })
                .FirstOrDefault(t => t.Id == id);

            trip.ReservedSeats = GetReservedSeats(trip.Id);

            return trip;
        }

        public IEnumerable<string> IsTripInputModelValid(TripInputModel input)
        {
            var errorList = new List<string>();

            if (string.IsNullOrWhiteSpace(input.StartPoint))
            {
                errorList.Add(InvalidStartPoint);
            }

            if (string.IsNullOrWhiteSpace(input.EndPoint))
            {
                errorList.Add(InvalidEndPoint);
            }

            if (string.IsNullOrWhiteSpace(input.Description) || input.Description.Length > DescriptionMaxLength)
            {
                errorList.Add(string.Format(InvalidDescription, DescriptionMaxLength));
            }

            if (!int.TryParse(input.Seats, out int seats))
            {
                errorList.Add(string.Format(InvalidSeatsCount, MinSeats, MaxSeats));
            }
            else if(int.Parse(input.Seats) > 6 || int.Parse(input.Seats) < 2)
            {
                errorList.Add(string.Format(InvalidSeatsCount, MinSeats, MaxSeats));
            }

            if (!DateTime.TryParseExact(input.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var time))
            {
                errorList.Add(InvalidDeparturetime);
            }

            return errorList;
        }

        public bool IsUserAlreadyJoinedToTheTrip(string tripId, string userId)
        {
            var userTrip = this.dbContext.UsersTrips.FirstOrDefault(t => t.TripId == tripId && t.UserId == userId);
            return userTrip != null;
        }

        private int GetReservedSeats(string id)
        {
            var reservedSeats = this.dbContext.UsersTrips
                 .Where(t => t.TripId == id)
                 .Count();

            return reservedSeats;
        }
    }
}
