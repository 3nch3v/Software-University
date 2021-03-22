using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Warehouse.Models.ProductModels;

namespace Warehouse.Models.WarehouseModels
{
    public class Location
    {
        public Location()
        {
            LocationsProducts = new HashSet<LocationProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<LocationProduct> LocationsProducts { get; set; }
    }
}
