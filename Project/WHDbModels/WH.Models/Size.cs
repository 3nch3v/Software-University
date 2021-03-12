using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WH.Models
{
    public class Size
    {
        public Size()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Value { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
