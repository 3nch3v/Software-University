using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Warehouse.Models.ProductModels;

namespace Warehouse.Models.CustomerModels
{
    public class Customer
    {
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

        public InvoiceAddress InvoiceAddress { get; set; }

        public ICollection<ShippingAddress> ShippingAddresses { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
