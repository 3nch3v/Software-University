namespace SoftJail.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using SoftJail.Data.Models.Enums;

    public class Officer
    {
        public Officer()
        {
            OfficerPrisoners = new HashSet<OfficerPrisoner>();
        }

        public int Id { get; set; }

        [Required] public string FullName { get; set; }

        public decimal Salary { get; set; }

        public Position Position { get; set; }

        public Weapon Weapon { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }
    }
}
