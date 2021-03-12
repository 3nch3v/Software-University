using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Warehouse.Models
{
    public class Color
    {
        public Color()
        {
            SizeColorProduct = new HashSet<SizeColorProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Name { get; set; }

        public ICollection<SizeColorProduct> SizeColorProduct { get; set; }
    }
}
