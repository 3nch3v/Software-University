using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models.ProductModels
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FileName { get; set; }

        [MaxLength(2048)]
        public string URL { get; set; }
    }
}
