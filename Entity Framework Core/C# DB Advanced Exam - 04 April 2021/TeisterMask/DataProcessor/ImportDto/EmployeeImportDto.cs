using System.ComponentModel.DataAnnotations;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class EmployeeImportDto
    {
        [Required]
        [MaxLength(GlobalConstants.EMPLOYEE_USERNAME_MAX_LENGTH)]
        [MinLength(GlobalConstants.EMPLOYEE_USERNAME_MIN_LENGTH)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(GlobalConstants.EMPLOYEE_PHONE_LENGTH)]
        [MinLength(GlobalConstants.EMPLOYEE_PHONE_LENGTH)]
        [RegularExpression(@"\d\d\d-\d\d\d-\d\d\d\d")]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }
}
