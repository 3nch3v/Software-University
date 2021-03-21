using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Warehouse.Models.EmployeeModels;
using Warehouse.Models.ProductModels;

namespace Warehouse.Models.WarehouseModels
{
    public class Box
    {
        public Box()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Barcode { get; set; }

        public int DestinationId { get; set; }
        public virtual Destination Destination { get; set; }

        public bool IsEmpty { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
