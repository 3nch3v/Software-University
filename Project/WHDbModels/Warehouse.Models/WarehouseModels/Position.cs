﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Warehouse.Models.ProductModels;

namespace Warehouse.Models.WarehouseModels
{
   public class Position
    {
        public Position()
        {
            PositionsProducts = new HashSet<PositionProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<PositionProduct> PositionsProducts { get; set; }
    }
}
