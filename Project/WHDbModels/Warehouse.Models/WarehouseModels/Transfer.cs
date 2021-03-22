
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Warehouse.Models.EmployeeModels;

namespace Warehouse.Models.WarehouseModels
{
    public class Transfer
    {
        [Key]
        public int Id { get; set; }

        public int BoxId { get; set; }
        public virtual Box Box { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public bool IsDone { get; set; }
    }
}
