
using System.ComponentModel.DataAnnotations;
using Warehouse.Models.ProductModels;

namespace Warehouse.Models.WarehouseModels
{
    public class PickUpList
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        //public Destination Destination { get; set; }

        //public User User { get; set; }

        public bool IsPickedUp { get; set; }


        //TODO should check the count of items for order 
        public bool IsMultipleItems { get; set; }
    }
}
