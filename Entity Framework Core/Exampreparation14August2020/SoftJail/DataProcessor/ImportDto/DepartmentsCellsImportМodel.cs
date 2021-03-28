using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    using System.Collections.Generic;

    public class DepartmentsCellsImportМodel
    {
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<CellImportModel> Cells { get; set; }
    }

    public class CellImportModel
    {
        [Range(1, 1000)]
        public int CellNumber { get; set; }
        public bool HasWindow { get; set; }
    }
}

