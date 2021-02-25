using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            string result = RemoveTown(context);
            Console.WriteLine(result);
        }

        //15.     Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                              .Include(x => x.Addresses)
                              .FirstOrDefault(x => x.Name == "Seattle");

            var addressesIds = town.Addresses
                                   .Select(x => x.AddressId)
                                   .ToList();

            var employees = context.Employees
                                   .Where(x => x.AddressId.HasValue && addressesIds.Contains(x.AddressId.Value))
                                   .ToList();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            foreach (var addressId in addressesIds)
            {
                var address = context.Addresses.FirstOrDefault(x => x.AddressId == addressId);
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);
            context.SaveChanges();

            return $"{addressesIds.Count} addresses in Seattle were deleted";
        }

        //14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var removeProject = context.Projects.FirstOrDefault(x => x.ProjectId == 1);

            var allEmployeesProjects = context.EmployeesProjects.Where(x => x.ProjectId == 1);

            foreach (var project in allEmployeesProjects)
            {
                context.EmployeesProjects.Remove(project);
            }

            context.SaveChanges();

            context.Projects.Remove(removeProject);
            context.SaveChanges();

            var projects = context
                .Projects.Select(x => new { x.Name })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        //13.	Find Employees by First Name Starting with "Sa"
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => EF.Functions.Like(x.FirstName, "Sa%"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //12.	Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] departments = new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }; 

            var updateEmployesSalaries = context.Employees
                .Where(x => departments.Contains(x.Department.Name))
                .ToList();

            foreach (var employee in updateEmployesSalaries)
            {
                employee.Salary *= 1.12M;
            }

            context.SaveChanges();

            var employees = context.Employees
                .Where(x => departments.Contains(x.Department.Name))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //11.	Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    x.StartDate
                })
                .OrderBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate}");
            }

            return sb.ToString().TrimEnd();
        }

        //10.	Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments 
                                    .Where(x => x.Employees.Count > 5)
                                    .OrderBy(x => x.Employees.Count)
                                    .ThenBy(x => x.Name)
                                    .Select(x => new
                                    {
                                        DepartmentName = x.Name,
                                        ManagerFirstName = x.Manager.FirstName,
                                        ManagerLastName = x.Manager.LastName,
                                        EmployeesInTheDepartment = x.Employees.Select(x => new
                                        {
                                            EmployeeFirstName = x.FirstName,
                                            EmployeeLastName = x.LastName,
                                            EmployeeJobTitle = x.JobTitle
                                        })
                                           .OrderBy(x => x.EmployeeFirstName)
                                           .ThenBy(x => x.EmployeeLastName)
                                           .ToList()
                                    })
                                    .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} – {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.EmployeesInTheDepartment)
                {
                    sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - {employee.EmployeeJobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }                           

        //9.	Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var employeeId147 = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = x.EmployeesProjects
                                .Select(x => new { x.Project.Name })
                                .OrderBy(x => x.Name)
                                .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var empl in employeeId147)
            {
                sb.AppendLine($"{empl.FirstName} {empl.LastName} - {empl.JobTitle}");

                foreach (var project in empl.Projects)
                {
                    sb.AppendLine(project.Name);
                }
            }

            return sb.ToString().TrimEnd();
        }

        //8.	Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                    .Select(x => new
                    {
                        Address = x.AddressText,
                        TownName = x.Town.Name,
                        Count = x.Employees.Count
                    })
                    .OrderByDescending(x => x.Count)
                    .ThenBy(x => x.TownName)
                    .ThenBy(x => x.Address)
                    .Take(10)
                    .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.Address}, {address.TownName} - {address.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //7.	Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                                   .Where(x => x.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001
                                                                         && p.Project.StartDate.Year <= 2003))
                                   .Select(x => new 
                                    { 
                                       EmployeeFirstName = x.FirstName,
                                       EmployeeLastName = x.LastName,
                                       ManagerFirstName = x.Manager.FirstName,
                                       ManagerLastName = x.Manager.LastName,
                                       Projects = x.EmployeesProjects.Select(x => new
                                           { 
                                              ProjectName = x.Project.Name,
                                              ProjectStartDate = x.Project.StartDate,
                                              ProjectEndDate = x.Project.EndDate,
                                           })
                                    })
                                   .Take(10)
                                   .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var emplProjects in employee.Projects)
                {
                    var endDate = emplProjects.ProjectEndDate == null ? "not finished" : emplProjects.ProjectEndDate.ToString();

                    sb.AppendLine($"--{emplProjects.ProjectName} - {emplProjects.ProjectStartDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //6.	Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address {
                                        AddressText = "Vitoshka 15",
                                        TownId = 4
                                      };

            context.Addresses.Add(address);
            context.SaveChanges();

            var nakov = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
            nakov.AddressId = address.AddressId;
            context.SaveChanges();

            var employeesAddresses = context.Employees
                                            .Select(x => new
                                            {
                                                x.AddressId,
                                                x.Address
                                            })
                                            .OrderByDescending(x => x.AddressId)
                                            .Take(10)
                                            .ToList();



            StringBuilder sb = new StringBuilder();

            foreach (var employeeAddress in employeesAddresses)
            {
                sb.AppendLine(employeeAddress.Address.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        //5.	Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new 
                { 
                    x.FirstName,
                    x.LastName,
                    x.Department,
                    x.Salary
                })
                .Where(x => x.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //4.	Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context
                                  .Employees
                                  .Select(x => new {
                                                    x.FirstName,
                                                    x.Salary})
                                  .Where(x => x.Salary > 50000)
                                  .OrderBy(x => x.FirstName)
                                  .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //3.	Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context
                                .Employees
                                .Select(x => new
                                {
                                    x.EmployeeId,
                                    x.FirstName,
                                    x.LastName,
                                    x.MiddleName,
                                    x.JobTitle,
                                    x.Salary
                                })
                                .OrderBy(x => x.EmployeeId)
                                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd(); 
        }
    }
}
