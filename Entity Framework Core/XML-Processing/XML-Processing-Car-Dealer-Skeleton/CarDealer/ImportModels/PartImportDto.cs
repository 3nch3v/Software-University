using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.ImportModels
{
    [XmlType("partId")]
    public class PartImportDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
