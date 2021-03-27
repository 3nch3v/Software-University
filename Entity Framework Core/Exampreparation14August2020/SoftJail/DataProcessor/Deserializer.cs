


using SoftJail.Data.Models.Enums;
using XmlFacade;

namespace SoftJail.DataProcessor
{ 
    using System;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;
    using Data;
    using Data.Models;
    using ImportDto;


    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsCellsDtos = JsonConvert.DeserializeObject<ICollection<DepartmentsCellsImportmodel>>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Department> departments = new List<Department>();

            foreach (var currDepartment in departmentsCellsDtos)
            {
                if (!IsValid(currDepartment)
                    || !currDepartment.Cells.Any()
                    || !currDepartment.Cells.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department newDepartment = new Department
                {
                    Name = currDepartment.Name,
                    Cells = currDepartment.Cells.Select(c => new Cell
                    {
                        CellNumber = c.CellNumber,
                        HasWindow = c.HasWindow
                    }).ToList()
                };

                sb.AppendLine($"Imported {newDepartment.Name} with {newDepartment.Cells.Count} cells");
                departments.Add(newDepartment);
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersMailsDtos = JsonConvert.DeserializeObject<ICollection<PrisonersMailsImportModel>>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Prisoner> prisoners = new List<Prisoner>();

            foreach (var currPrisoner in prisonersMailsDtos)
            {
                if (!IsValid(currPrisoner)
                    || !currPrisoner.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var date = DateTime.ParseExact(currPrisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var isValidDate = DateTime.TryParseExact(currPrisoner.IncarcerationDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime releaseDate);

                Prisoner newPrisoner = new Prisoner
                {
                    FullName = currPrisoner.FullName,
                    Nickname = currPrisoner.Nickname,
                    Age = currPrisoner.Age,
                    IncarcerationDate = date,
                    ReleaseDate = isValidDate ? (DateTime?)releaseDate : null,
                    Bail = currPrisoner.Bail,
                    CellId = currPrisoner.CellId,
                    Mails = currPrisoner.Mails.Select(m => new Mail
                    {
                        Description = m.Description,
                        Sender = m.Sender,
                        Address = m.Address
                    }).ToList()
                };

                sb.AppendLine($"Imported {newPrisoner.FullName} {newPrisoner.Age} years old");
                prisoners.Add(newPrisoner);
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var officersPrisonersDtos = XmlConverter.Deserializer<OfficersPrisonersInputModel>(xmlString, "Officers");

            StringBuilder sb = new StringBuilder();
            List<Officer> officers = new List<Officer>();

            foreach (var cuurOfficers in officersPrisonersDtos)
            {
                if (!IsValid(cuurOfficers))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Officer newOfficer = new Officer
                {
                    FullName = cuurOfficers.Name,
                    Salary = cuurOfficers.Money,
                    Position = Enum.Parse<Position>(cuurOfficers.Position),
                    Weapon = Enum.Parse<Weapon>(cuurOfficers.Weapon),
                    DepartmentId = cuurOfficers.DepartmentId,
                    OfficerPrisoners = cuurOfficers.Prisoners.Select(p => new OfficerPrisoner
                    {
                        PrisonerId = p.Id
                    }).ToList()
                };

                sb.AppendLine($"Imported {newOfficer.FullName} ({newOfficer.OfficerPrisoners.Count} prisoners)");
                officers.Add(newOfficer);
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}