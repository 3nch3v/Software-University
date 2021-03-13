using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models.CustomerModels
{
    public class ShippingAddress
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        [MaxLength(35)]
        public string CareOf { get; set; }

        [Required]
        [MaxLength(50)]
        public string Street { get; set; }

        [Required]
        [MaxLength(10)]
        public string StreetNumber { get; set; }

        [Required]
        [MaxLength(10)]
        public string ZIPCode { get; set; }

        [Required]
        [MaxLength(35)]
        public string City { get; set; }

        [Required]
        [MaxLength(35)]
        public string Country { get; set; }
    }
}
