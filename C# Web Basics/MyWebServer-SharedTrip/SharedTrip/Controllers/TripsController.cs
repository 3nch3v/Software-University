using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Services.Contracts;
using SharedTrip.ViewModels.TripModels;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        [Authorize]
        public HttpResponse Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(TripInputModel input)
        {
            if (this.tripsService.IsTripInputModelValid(input).Any())
            {
                return this.View();
            }

            this.tripsService.AddAsync(input);

            return this.Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var trips = new AllTripsViewmodel
            {
                Trips = this.tripsService.All(),
            };

            return this.View(trips);
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var trip = this.tripsService.GetById(tripId);

            if (trip == null)
            {
                return this.Redirect("/Trips/All");
            }

            return this.View(trip);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var userId = this.User.Id;

            if (this.tripsService.IsUserAlreadyJoinedToTheTrip(tripId, userId))
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }

            this.tripsService.AddUserToTripAsync(tripId, userId);

            return this.Redirect("/Trips/All");
        }
    }
}
