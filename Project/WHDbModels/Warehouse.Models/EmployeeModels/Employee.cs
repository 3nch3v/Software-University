using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models.EmployeeModels
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required] 
        [MaxLength(101)] 
        public string Username => $"{FirstName}.{LastName}";

        public bool isLoggedIn { get; set; }

        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

    }
}
