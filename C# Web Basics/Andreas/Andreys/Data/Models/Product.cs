namespace Andreys.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Andreys.Data.Enums;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Name { get; set; }


        [MaxLength(10)]
        public string Description { get; set; }

        [MaxLength(2048)]
        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

       public Gender Gender { get; set; }
    }
}