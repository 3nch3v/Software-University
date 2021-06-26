namespace Panda.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Receipt
    {
        public Receipt()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        [Required]
        [ForeignKey("Recipient")]
        public string RecipientId { get; set; }

        public User Recipient { get; set; }

        [Required]
        [ForeignKey("Package")]
        public string PackageId { get; set; }
        public Package Package { get; set; }
    }
}