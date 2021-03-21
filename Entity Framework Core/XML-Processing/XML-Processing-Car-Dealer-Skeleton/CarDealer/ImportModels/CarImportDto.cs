
using System.Xml.Serialization;

namespace CarDealer.ImportModels
{
    [XmlType("Car")]
    public class CarImportDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public PartImportDto[] PartsIds { get; set; }

    }
}
