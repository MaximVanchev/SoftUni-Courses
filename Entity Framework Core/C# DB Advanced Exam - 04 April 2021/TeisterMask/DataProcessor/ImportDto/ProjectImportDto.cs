using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ProjectImportDto
    {
        [Required]
        [MaxLength(GlobalConstants.PROJECT_NAME_MAX_LENGTH)]
        [MinLength(GlobalConstants.PROJECT_NAME_MIN_LENGTH)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }

        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public virtual TaskImportDto[] Tasks { get; set; }
    }
}
