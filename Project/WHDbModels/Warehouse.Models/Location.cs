﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Warehouse.Models.ProductModels;

namespace Warehouse.Models
{
    public class Location
    {
        public Location()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
