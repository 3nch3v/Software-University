using SharedTrip.Data;
using SharedTrip.ViewModels.Trips;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedTrip.Services.Contracts
{
    public interface ITripsService
    {
        Task Add(TripInputModel input);

        IEnumerable<AllTripsViewmodel> GetAll();

        TripViewModel GetDetails(string id);

        Task<bool> AddAddUserToTrip(string tripId, string userId);
    }
}
