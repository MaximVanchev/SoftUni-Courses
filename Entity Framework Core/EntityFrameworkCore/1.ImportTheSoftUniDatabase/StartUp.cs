using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();
            Console.WriteLine(RemoveTown(db));   
        }

        //3. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            Employee[] employees = context.Employees.OrderBy(e => e.EmployeeId).ToArray();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }
            return sb.ToString().Trim();
        }

        //4. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            Employee[] employees = context.Employees.Where(e => e.Salary > 50000).OrderBy(e => e.FirstName).ToArray();
            foreach (var employee in employees)
            {
                sb.AppendJoin(" - ", employee.FirstName, $"{ employee.Salary:F2}");
                sb.AppendLine();
            }
            return sb.ToString().Trim();
        }

        //5. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            Employee[] employees = context.Employees.Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName).ToArray();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:F2}");
            }
            return sb.ToString().Trim();
        }

        //6. Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            Employee[] employees = context.Employees.Where(e => e.LastName == "Nakov").ToArray();
            foreach (var employee in employees)
            {
                employee.Address = new Address() { AddressText = "Vitoshka 15", Town = new Town() { Name = " "} };
            }
            employees = context.Employees.OrderByDescending(e => e.AddressId).Take(10).ToArray();
            foreach (var employee in employees)
            {
                sb.AppendLine(employee.Address.AddressText);
            }
            return sb.ToString().Trim();
        }

        //7. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            int timeStrartYear = 2001;
            int timeEndYear = 2003;
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees.Where(e => e.EmployeesProjects
                .Any(ep => ep.Project.StartDate.Year >= timeStrartYear && ep.Project.StartDate.Year <= timeEndYear))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Project = e.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        ProjectStartDate = ep.Project.StartDate,
                        ProjectEndDate = ep.Project.EndDate
                    })
                }).Take(10);
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} " +
                    $"- Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
                foreach (var project in employee.Project)
                {
                    string startDate = project.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt");
                    string endDate = project.ProjectEndDate.HasValue ? 
                        project.ProjectEndDate.Value.ToString("M/d/yyyy h:mm:ss tt"):"not finished";
                    sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }
            return sb.ToString().Trim();
        }

        //8. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var addresses = context.Addresses.Select(a => new 
                { Address = a.AddressText , TownName = a.Town.Name , Count = a.Employees.Count() })
                    .OrderByDescending(a => a.Count).ThenBy(a => a.TownName).ThenBy(a => a.Address);

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.Address}, {address.TownName} - {address.Count} employees");
            }
            return sb.ToString().Trim();
        }

        //9. Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees.Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Project = e.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name
                    })
                });
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                foreach (var project in employee.Project.OrderBy(p => p.ProjectName))
                {
                    sb.AppendLine(project.ProjectName);
                }
            }
            return sb.ToString().Trim();
        }

        //10. Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var departments = context.Departments.Where(d => d.Employees.Count() > 5)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employee = d.Employees.Select(e => new
                    {
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        EmployeeJobTitle = e.JobTitle
                    })
                }).OrderBy(d => d.Employee.Count()).ThenBy(d => d.DepartmentName);
            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastName}");
                foreach (var employee in department.Employee.OrderBy(e => e.EmployeeFirstName).ThenBy(e => e.EmployeeLastName))
                {
                    sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - {employee.EmployeeJobTitle}");
                }
            }
            return sb.ToString().Trim();
        }

        //11. Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            Project[] projects = context.Projects.OrderByDescending(p => p.StartDate).Take(10).OrderBy(p => p.Name).ToArray();
            foreach (var project in projects)
            {
                string StartDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt");
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(StartDate);
            }
            return sb.ToString().Trim();
        }

        //12. Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Employee[] employees = context.Employees.Where(e => e.Department.Name == "Engineering" 
            || e.Department.Name == "Tool Design" 
            || e.Department.Name == "Marketing" 
            || e.Department.Name == "Information Services").OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToArray();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12M;
            }
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }
            return sb.ToString().Trim();
        }

        //13. Find Employees by First Name Starting With Sa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            string startsString = "sa";

            Employee[] employees = context.Employees.Where(e => e.FirstName.ToLower().StartsWith(startsString))
                .OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }
            return sb.ToString().Trim();
        }

        //14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            Project project = context.Projects.FirstOrDefault(p => p.ProjectId == 2);
            EmployeeProject employeeProject = (EmployeeProject)context.EmployeesProjects.FirstOrDefault(ep => ep.Project.Equals(project));
            context.Remove(employeeProject);
            context.Remove(project);
            Project[] projects = context.Projects.Take(10).ToArray();
            foreach (var project1 in projects)
            {
                sb.AppendLine(project1.Name);
            }
            return sb.ToString().Trim();
        }

        //15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            string townName = "Redmond";
            Town town = context.Towns.FirstOrDefault(t => t.Name == townName);
            Address[] addresses = context.Addresses.ToArray().Where(a => a.TownId == town.TownId).ToArray();
            Employee[] employees = context.Employees.ToArray().Where(e => addresses.Any(a => e.AddressId == a.AddressId)).ToArray();
            int removeCount = 0;
            foreach (var employee in employees)
            {
                employee.Address = null;
            }
            foreach (var address in addresses)
            {
                context.Remove(address);
                removeCount++;
            }
            context.Remove(town);
            return $"{removeCount} addresses in {townName} were deleted";
        }
    }
}
