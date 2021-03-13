
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Models.ProductModels
{
    public class Collection
    {
        public Collection()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
