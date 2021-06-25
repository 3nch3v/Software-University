namespace SharedTrip.ViewModels.TripModels
{
    public class TripDetailsViewModel : BaseTripViewModel
    {
        public string ImagePath { get; set; }

        public string Description { get; set; }

        public string DepartureTimeFormatted => DepartureTime.ToString("s");
    }
}
