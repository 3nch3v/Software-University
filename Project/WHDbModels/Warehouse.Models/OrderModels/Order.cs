using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Warehouse.Models.CustomerModels;
using Warehouse.Models.Enums;


namespace Warehouse.Models.OrderModels
{
    public class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
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

        //public decimal Amount => Products.Sum(x => x.Price);

        public bool IsPaid { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
