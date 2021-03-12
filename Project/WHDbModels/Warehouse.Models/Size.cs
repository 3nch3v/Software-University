using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Warehouse.Models
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

        public ICollection<SizeColorProduct> SizeColorProduct { get; set; }
    }
}
