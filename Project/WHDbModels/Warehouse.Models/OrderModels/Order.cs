using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Warehouse.Models.CustomerModels;
using Warehouse.Models.ProductModels;

namespace Warehouse.Models.OrderModels
{
    public class Order
    {
        public Order()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(35)]
        public string OrderNumber { get; set; }

        [Required]
        [MaxLength(35)]
        public string InvoiceNumber { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        [MaxLength(100)]
        public string PaymentMethod { get; set; }

        public decimal Amount => Products.Sum(x => x.Price);

        public bool IsPaid { get; set; }

        public bool IsDone { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
