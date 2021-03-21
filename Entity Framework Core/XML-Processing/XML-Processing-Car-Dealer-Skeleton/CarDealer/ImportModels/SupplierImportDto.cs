
using System.Xml.Serialization;

namespace CarDealer.ImportModels
{
    [XmlType("Supplier")]
    public class SupplierImportDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}
