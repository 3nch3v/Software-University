
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models.EmployeeModels
{
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
