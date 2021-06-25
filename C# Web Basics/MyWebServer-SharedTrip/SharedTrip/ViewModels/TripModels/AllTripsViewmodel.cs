using System.Collections.Generic;

namespace SharedTrip.ViewModels.TripModels
{
    public class AllTripsViewmodel
    {
        public IEnumerable<TripViewmodel> Trips { get; set; }
    }
}
