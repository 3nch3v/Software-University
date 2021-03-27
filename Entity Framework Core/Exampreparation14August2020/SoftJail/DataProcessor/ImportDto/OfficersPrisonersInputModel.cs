using System.ComponentModel.DataAnnotations;
using SoftJail.Data.Models.Enums;

namespace SoftJail.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Officer")]
    public class OfficersPrisonersInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [XmlElement("Money")]
        public decimal Money { get; set; }

        [Required]
        [EnumDataType(typeof(Position))]
        [XmlElement("Position")]
        public string Position { get; set; }

        [Required]
        [EnumDataType(typeof(Weapon))]
        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray]
        public PrisonerInputModel[] Prisoners { get; set; }
    }

    [XmlType("Prisoner")]
    public class PrisonerInputModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
