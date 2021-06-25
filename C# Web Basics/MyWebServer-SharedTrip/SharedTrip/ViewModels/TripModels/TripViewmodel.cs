using System.Globalization;

namespace SharedTrip.ViewModels.TripModels
{
    public class TripViewmodel : BaseTripViewModel
    {
        public string DepartureTimeAsString => DepartureTime.ToString(CultureInfo.GetCultureInfo("bg-BG"));
    }
}
