namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            StringBuilder sb = new StringBuilder();

            IMapper mapper = InitializeMapper();

            Project[] projects = context.Projects.Include(p => p.Tasks).Where(p => p.Tasks.Count > 0).ToArray();

            ProjectXmlExportDto[] projectXmlExportDtos = mapper
                .Map<Project[],ProjectXmlExportDto[]>(projects).ToArray();

            for (int i = 0; i < projects.Length; i++)
            {
                TaskXmlExportDto[] taskXmlExportDtos = mapper
                    .Map<Task[],TaskXmlExportDto[]>(projects[i].Tasks.OrderBy(t => t.Name).ToArray()).ToArray();

                projectXmlExportDtos[i].Tasks = taskXmlExportDtos;
            }

            projectXmlExportDtos = projectXmlExportDtos.OrderByDescending(p => p.TasksCount).ThenBy(p => p.ProjectName).ToArray();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);
            var serializer = new XmlSerializer(typeof(ProjectXmlExportDto[]), new XmlRootAttribute("Projects"));
            using (var stringWriter = new StringWriter(sb))
            {
                serializer.Serialize(stringWriter, projectXmlExportDtos, namespaces);
            }
            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            IMapper mapper = InitializeMapper();

            List<Employee> employees = context.Employees.Include(e => e.EmployeesTasks).ThenInclude(et => et.Task)
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .Where(e => e.EmployeesTasks.Count > 0).ToList();

            List<EmployeeExportDto> employeeExportDtos = mapper
                .Map<ICollection<Employee>,ICollection<EmployeeExportDto>>(employees).ToList();

            for (int i = 0; i < employees.Count; i++)
            {
                List<TaskExportDto> taskExportDtos = mapper.Map<ICollection<Task>, ICollection<TaskExportDto>>
                    (employees[i].EmployeesTasks.Select(e => e.Task).ToList())
                    .Where(t => DateTime.Parse(t.OpenDate) >= date)
                    .OrderByDescending(t => DateTime.ParseExact(t.DueDate , "d" , CultureInfo.InvariantCulture))
                    .ThenBy(t => t.TaskName).ToList();

                employeeExportDtos[i].Tasks = taskExportDtos;
            }

            employeeExportDtos = employeeExportDtos.OrderByDescending(e => e.Tasks.Count).ThenBy(e => e.Username).Take(10).ToList();

            string resultJson = JsonConvert.SerializeObject(employeeExportDtos, Formatting.Indented);

            return resultJson;
        }

        private static JsonSerializerSettings JsonSettings()
        {
            DefaultContractResolver defaultContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = defaultContractResolver
            };

            return jsonSerializerSettings;
        }

        private static IMapper InitializeMapper()
        {
            IConfigurationProvider configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TeisterMaskProfile>();
            });

            IMapper mapper = new Mapper(configuration);
            return mapper;
        }
    }
}