using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Warehouse.Models.EmployeeModels;
using Warehouse.Models.OrderModels;
using Warehouse.Models.ProductModels;

namespace Warehouse.Models.WarehouseModels
{
    public class TheWareHouse
    {
        public TheWareHouse()
        {
            Positions = new HashSet<Position>();
            Products = new HashSet<Product>();
            Locations = new HashSet<Location>();
            //PickUpLists = new HashSet<PickUpList>();
            TransportBoxes = new HashSet<Box>();
            Destinations = new HashSet<Destination>();
            Orders = new HashSet<Order>();
            Employees = new HashSet<Employee>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Position> Positions { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        //public virtual ICollection<PickUpList> PickUpLists { get; set; }

        public virtual ICollection<Box> TransportBoxes { get; set; }

        public virtual ICollection<Destination> Destinations { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
