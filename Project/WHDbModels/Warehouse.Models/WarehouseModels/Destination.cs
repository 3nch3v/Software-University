
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models.WarehouseModels
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
