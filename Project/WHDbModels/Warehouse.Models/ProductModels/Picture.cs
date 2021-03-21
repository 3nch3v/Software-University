using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models.ProductModels
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(2048)]
        public string URL { get; set; }
    }
}
