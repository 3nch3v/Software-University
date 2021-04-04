namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using Data.Models.Enums;

    [XmlType("Project")]
    public class ProjectImportModel
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }

        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public TaskImport[] Tasks { get; set; }
    }

    [XmlType("Task")]
    public class TaskImport
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }

        [Required]
        public string DueDate { get; set; }

        [Required]
        [EnumDataType(typeof(ExecutionType))]
        public string ExecutionType { get; set; }

        [Required]
        [EnumDataType(typeof(LabelType))]
        public string LabelType { get; set; }
    }
}
