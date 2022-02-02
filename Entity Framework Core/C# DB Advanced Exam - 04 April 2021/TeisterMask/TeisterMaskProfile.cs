namespace TeisterMask
{
    using AutoMapper;
    using System;
    using System.Globalization;
    using System.Linq;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ExportDto;

    public class TeisterMaskProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TeisterMaskProfile()
        {
            //Task
            CreateMap<Task, TaskExportDto>()
            .ForMember(x => x.TaskName, y => y.MapFrom(s => s.Name))
            .ForMember(x => x.OpenDate, y => y.MapFrom(s => s.OpenDate.ToString("d", CultureInfo.InvariantCulture)))
            .ForMember(x => x.DueDate, y => y.MapFrom(s => s.DueDate.ToString("d", CultureInfo.InvariantCulture)))
            .ForMember(x => x.LabelType, y => y.MapFrom(s => s.LabelType.ToString()))
            .ForMember(x => x.ExecutionType, y => y.MapFrom(s => s.ExecutionType.ToString()));

            CreateMap<Task, TaskXmlExportDto>()
                .ForMember(x => x.Label, y => y.MapFrom(s => s.LabelType.ToString()));

            //Project
            CreateMap<Project, ProjectXmlExportDto>()
                .ForMember(x => x.TasksCount, y => y.MapFrom(s => s.Tasks.Count))
                .ForMember(x => x.ProjectName, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.HasEndDate, y => y.MapFrom(s => s.DueDate.HasValue ? "Yes" : "No"));

            //Employee
            CreateMap<Employee, EmployeeExportDto>();
        }
    }
}
