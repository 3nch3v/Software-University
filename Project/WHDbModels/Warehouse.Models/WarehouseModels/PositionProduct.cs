
using Warehouse.Models.ProductModels;

namespace Warehouse.Models.WarehouseModels
{
    public class PositionProduct
    {
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
