namespace SoftJail.DataProcessor
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using Data;
    using ExportDto;
    using XmlFacade;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        { 
            var prisoners = context.Prisoners
                //.ToList() judge throws an error without to materialize it
                .Where(p => ids.Contains(p.Id))
                .Select(p => new 
                {
                   Id = p.Id,
                   Name = p.FullName,
                   CellNumber = p.Cell.CellNumber,
                   Officers = p.PrisonerOfficers.Select(o => new 
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    })
                       .OrderBy(o => o.OfficerName)
                       .ToList(),
                   TotalOfficerSalary = p.PrisonerOfficers.Sum(o => o.Officer.Salary)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToList();

            var json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();

            var prisoners = context.Prisoners
                .Where(p => names.Contains(p.FullName))
                .Select(p => new PrisonersByNamesExportModel
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails.Select(m => new MessageExportModel
                        {
                            Description = string.Join("", m.Description.Reverse())
                        })
                        .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToList();

            var result = XmlConverter.Serialize(prisoners, "Prisoners");

            return result;
        }
    }
}