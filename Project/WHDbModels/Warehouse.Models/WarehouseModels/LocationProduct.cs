
using Warehouse.Models.ProductModels;

namespace Warehouse.Models.WarehouseModels
{
    public class LocationProduct
    {
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}

