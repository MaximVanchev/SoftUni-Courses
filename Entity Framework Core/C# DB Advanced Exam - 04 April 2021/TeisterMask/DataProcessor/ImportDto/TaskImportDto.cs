using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class TaskImportDto
    {
        [Required]
        [MaxLength(GlobalConstants.TASK_NAME_MAX_LENGTH)]
        [MinLength(GlobalConstants.TASK_NAME_MIN_LENGTH)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }

        [Required]
        public string DueDate { get; set; }

        [Required]
        [Range(GlobalConstants.TASK_EXECUTION_MIN_VALUE,GlobalConstants.TASK_EXECUTION_MAX_VALUE)]
        public int ExecutionType { get; set; }

        [Required]
        [Range(GlobalConstants.TASK_LABEL_MIN_VALUE, GlobalConstants.TASK_LABEL_MAX_VALUE)]
        public int LabelType { get; set; }
    }
}
