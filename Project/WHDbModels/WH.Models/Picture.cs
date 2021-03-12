using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WH.Models
{
    public class Picture
    {
        public Picture()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(2048)]
        public string URL { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
