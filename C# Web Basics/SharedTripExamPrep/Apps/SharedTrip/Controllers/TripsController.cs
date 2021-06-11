using SharedTrip.Services.Contracts;
using SharedTrip.ViewModels.Trips;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Globalization;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trips = this.tripsService.GetAll();
            return this.View(trips);
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }


            var trip = this.tripsService.GetDetails(tripId);

            if (trip == null)
            {
                this.Error("Invalid Trip!");
            }

            return this.View(trip);
        }


        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.StartPoint))
            {
                this.Error("Please enter valid Start Point");
            }
            if (string.IsNullOrWhiteSpace(input.EndPoint))
            {
                this.Error("Please enter valid End Point");
            }
            if (input.Seats < 2 || input.Seats > 6)
            {
                this.Error("Seats schould be between 2 and 6");
            }
            if (string.IsNullOrWhiteSpace(input.Description)
                || input.Description.Length > 80)
            {
                this.Error("Despription should be between 1 and 80 characters!");
            }
            if (DateTime.TryParseExact(input.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                this.Error("Invalid time!");
            }

            this.tripsService.Add(input);
            return this.Redirect("/Trips/All");
        }

        [HttpGet]
        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var result = this.tripsService.AddAddUserToTrip(tripId, userId);

            if (!result.Result)
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }

            return this.Redirect("/Trips/All");
        }
    }
}
