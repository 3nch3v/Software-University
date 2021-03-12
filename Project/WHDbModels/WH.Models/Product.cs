using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WH.Models.Enums;

namespace WH.Models
{
    public class Product
    {
        public Product()
        {
            Collections = new HashSet<Collection>();
            Pictures = new HashSet<Picture>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(250)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string Vendor { get; set; }

        public ProductType ProductType { get; set; }

        public int? Barcode { get; set; }

        [StringLength(50)]
        public string SKU { get; set; }

        public bool? PhysicalProduct { get; set; }

        public int? CountryOfOriginId { get; set; }

        public CountryOfOrigin CountryOfOrigin { get; set; }

        public double? Weight { get; set; }

        public Size Size { get; set; }

        public Color Color { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(3000)")]
        public string Description { get; set; }

        public ICollection<Collection> Collections { get; set; }

        public ICollection<Picture> Pictures { get; set; }

        public decimal? CostPerItem { get; set; }

        public decimal? Price { get; set; }

        [DefaultValue(0)]
        public int Quantity { get; set; }

        public bool? IsActive { get; set; }
    }
}
