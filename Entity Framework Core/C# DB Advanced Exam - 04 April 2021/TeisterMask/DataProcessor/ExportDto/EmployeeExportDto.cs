using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class EmployeeExportDto
    {
        public string Username { get; set; }

        [NotMapped]
        public ICollection<TaskExportDto> Tasks { get; set; }
    }
}
