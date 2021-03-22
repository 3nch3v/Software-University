using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Warehouse.Models.OrderModels;
using Warehouse.Models.WarehouseModels;
using WH.Models.Enums;

namespace Warehouse.Models.ProductModels
{
    public class Product
    {
        public Product()
        {
            Collections = new HashSet<Collection>();
            Pictures = new HashSet<Picture>();
            SizeColorProduct = new HashSet<SizeColorProduct>();
            PositionsProducts = new HashSet<PositionProduct>();
            LocationsProducts = new HashSet<LocationProduct>();
            OrderProducts = new HashSet<OrderProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(250)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string Vendor { get; set; }

        public ProductType? ProductType { get; set; }

        public int? Barcode { get; set; }

        [StringLength(50)]
        public string SKU { get; set; }

        public bool? PhysicalProduct { get; set; }

        public int? CountryOfOriginId { get; set; }
        public virtual CountryOfOrigin CountryOfOrigin { get; set; }

        public double? Weight { get; set; }


        [Column(TypeName = "NVARCHAR(3000)")]
        public string Description { get; set; }

      
        public decimal? CostPerItem { get; set; }

        public decimal Price { get; set; }

        public decimal? CompareToPrice { get; set; }

        public bool? IsActive { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }


        public virtual ICollection<PositionProduct> PositionsProducts { get; set; }

        public virtual ICollection<LocationProduct> LocationsProducts { get; set; }


        public virtual ICollection<SizeColorProduct> SizeColorProduct { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
