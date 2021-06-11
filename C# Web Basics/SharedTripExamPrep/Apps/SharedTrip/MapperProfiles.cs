using AutoMapper;
using SharedTrip.Data;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            this.CreateMap<TripInputModel, Trip>();
        }
    }
}
