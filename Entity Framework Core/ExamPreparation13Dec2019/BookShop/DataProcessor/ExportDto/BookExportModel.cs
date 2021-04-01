using System;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ExportDto
{
    [XmlType("Book")]
    public class BookExportModel
    {
        [XmlAttribute(AttributeName = "Pages")]
        public int Pages { get; set; }

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }
    }
}
