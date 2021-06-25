using SharedTrip.ViewModels.TripModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedTrip.Services.Contracts
{
    public interface ITripsService
    {
        IEnumerable<TripViewmodel> All();

        IEnumerable<string> IsTripInputModelValid(TripInputModel input);

        Task AddAsync(TripInputModel input);

        TripDetailsViewModel GetById(string id);

        Task AddUserToTripAsync(string tripId, string userId);

        bool IsUserAlreadyJoinedToTheTrip(string tripId, string userId);
    }
}
