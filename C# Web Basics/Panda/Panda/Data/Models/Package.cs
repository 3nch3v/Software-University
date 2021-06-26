namespace Panda.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Panda.Data.Enums;

    public class Package
    {
        public Package()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime EstimatedDelivery { get; set; }

        [Required]
        [ForeignKey("Recipient")]
        public string RecipientId { get; set; }

        public User Recipient { get; set; }
    }
}