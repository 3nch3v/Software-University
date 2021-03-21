
using System.Xml.Serialization;

namespace CarDealer.ExportModels
{
    [XmlType("car")]
    public class CarsWithTravelledDistanceExportModel
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }

    }
}
