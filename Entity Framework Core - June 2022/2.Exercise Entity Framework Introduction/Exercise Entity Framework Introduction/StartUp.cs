using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public  class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            string result = GetEmployeesFromResearchAndDevelopment(dbContext);

            Console.WriteLine(result);
        }

        //03. Employees Full Information

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var allEmployees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e=>new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var employee in allEmployees)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }


        //05. Employees from Research and Development 

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var rndEmployees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToArray();

            foreach (var e in rndEmployees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }


        //06. Adding a New Address and Updating Employee 

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            Employee nakov = context.Employees
                .First(e => e.LastName == "Nakov");

            nakov.Address = newAddress;

            context.SaveChanges();

            string[] addressTexts = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToArray();

            foreach (var text in addressTexts)
            {
                sb.AppendLine(text);
            }

            return sb.ToString().TrimEnd();
        }

        //07. Employees and Projects

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Include(x => x.EmployeesProjects).ThenInclude(x => x.Project)
                .Where(x => x.EmployeesProjects
                    .Select(x => x.Project)
                    .Any(x => x.StartDate.Year >= 2001 && x.StartDate.Year <= 2003))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(x => x.Project)
                });

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    string endDate = "not finished";
                    if (project.EndDate != null)
                    {
                        endDate = $"{project.EndDate:M/d/yyyy h:mm:ss tt}";
                    }
                    sb.AppendLine($"--{project.Name} - {project.StartDate:M/d/yyyy h:mm:ss tt} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //14. Delete Project by Id

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            Project projToDelete = context.Projects.Find(2);

            EmployeeProject[] referredEmployees = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == projToDelete.ProjectId)
                .ToArray();

            context.EmployeesProjects.RemoveRange(referredEmployees);
            context.Projects.Remove(projToDelete);
            context.SaveChanges();

            string[] projectNames = context
                .Projects
                .Take(10)
                .Select(p => p.Name)
                .ToArray();

            foreach (var name in projectNames)
            {
                output.AppendLine(name);
            }

            return output.ToString().TrimEnd();
        }




    }
}
