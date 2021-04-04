namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using ExportDto;
    using Data;

    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProjectexportModel[]), new XmlRootAttribute("Projects"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            using StringWriter stringWriter = new StringWriter(sb);

            var projectsWithTasks = context.Projects
                .ToArray()
                .Where(p => p.Tasks.Any())
                .Select(p => new ProjectexportModel()
                {
                    ProjectName = p.Name,
                    TasksCount = p.Tasks.Count,
                    HasEndDate = p.DueDate != null ? "Yes" : "No",
                    Tasks = p.Tasks.Select(t => new TaskExport
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                        .ToArray()
                        .OrderBy(t => t.Name)
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, projectsWithTasks, namespaces);
            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .ToArray()
                .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .ToArray()
                        .Where(t => t.Task.OpenDate >= date)
                        .OrderByDescending(t => t.Task.DueDate)
                        .ThenBy(t => t.Task.Name)
                        .Select(t => new
                        {
                            TaskName = t.Task.Name,
                            OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = t.Task.LabelType.ToString(),
                            ExecutionType = t.Task.ExecutionType.ToString(),
                        })
                        .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            var jsonOutput = JsonConvert.SerializeObject(employees, Formatting.Indented);
            return jsonOutput;
        }
    }
}