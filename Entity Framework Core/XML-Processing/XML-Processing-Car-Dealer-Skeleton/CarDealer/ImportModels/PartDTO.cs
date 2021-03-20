using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.ImportModels
{
    [XmlType("partId")]
    public class PartDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
