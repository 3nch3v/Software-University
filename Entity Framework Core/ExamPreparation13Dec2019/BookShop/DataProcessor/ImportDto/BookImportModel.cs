using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using BookShop.Data.Models.Enums;

namespace BookShop.DataProcessor.ImportDto
{
	[XmlType("Book")]
    public class BookImportmodel
    {

        [XmlElement(ElementName = "Name")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }


        [XmlElement(ElementName = "Genre")]
        [EnumDataType(typeof(Genre))]
        public string Genre { get; set; }


        [XmlElement(ElementName = "Price")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }


        [XmlElement(ElementName = "Pages")]
        [Range(50, 5000)]
        public int Pages { get; set; }


        [XmlElement(ElementName = "PublishedOn")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy}")]
        public string PublishedOn { get; set; }
    }
}
