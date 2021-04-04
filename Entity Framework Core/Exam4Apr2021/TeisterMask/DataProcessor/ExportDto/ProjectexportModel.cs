namespace TeisterMask.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Project")]
    public class ProjectexportModel
    {
        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [XmlElement("ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public TaskExport[] Tasks { get; set; }

    }

    [XmlType("Task")]
    public class TaskExport
    {
        [XmlElement("Name")] 
        public string Name { get; set; }

        [XmlElement("Label")] 
        public string Label { get; set; }
    }
}