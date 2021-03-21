using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models.ProductModels
{
    public class Size
    {
        public Size()
        {
            SizeColorProduct = new HashSet<SizeColorProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Value { get; set; }

        public virtual ICollection<SizeColorProduct> SizeColorProduct { get; set; }
    }
}
