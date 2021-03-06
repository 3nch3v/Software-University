﻿
using System.Xml.Serialization;

namespace CarDealer.ImportModels
{
    [XmlType("Sale")]
    public class SalesImportDto
    {
        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }

        [XmlElement("discount")]
        public int Discount { get; set; }
    }
}
