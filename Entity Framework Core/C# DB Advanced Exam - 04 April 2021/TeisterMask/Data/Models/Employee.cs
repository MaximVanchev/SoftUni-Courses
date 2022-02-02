using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeisterMask.Common;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        public Employee()
        {
            EmployeesTasks = new HashSet<EmployeeTask>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.EMPLOYEE_USERNAME_MAX_LENGTH)]
        public string Username { get; set; }

        [Required]
        [EmailAddress()]
        public string Email { get; set; }

        [Required]
        [MaxLength(GlobalConstants.EMPLOYEE_PHONE_LENGTH)]
        public string Phone { get; set; }

        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; }
    }
}
