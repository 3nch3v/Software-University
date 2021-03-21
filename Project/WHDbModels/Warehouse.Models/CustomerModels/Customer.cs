using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Warehouse.Models.OrderModels;

namespace Warehouse.Models.CustomerModels
{
    public class Customer
    {
        public Customer()
        {
            ShippingAddresses = new HashSet<ShippingAddress>();
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EMail { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 8)]
        public string Password { get; set; }

        public virtual InvoiceAddress InvoiceAddress { get; set; }

        public virtual ICollection<ShippingAddress> ShippingAddresses { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
