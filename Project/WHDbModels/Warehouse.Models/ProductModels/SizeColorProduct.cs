﻿
namespace Warehouse.Models.ProductModels
{
    public class SizeColorProduct
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int SizeId { get; set; }
        public virtual Size Size { get; set; }

        public int ColorId { get; set; }
        public virtual Color Color { get; set; }

        public int Quantity { get; set; }
    }
}
