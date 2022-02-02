using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel.DataAnnotations;
using StackExchange.Redis;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            HomeworkSubmissions = new HashSet<HomeworkSubmissions>();
            StudentCourses = new HashSet<StudentCourse>();
        }
        [Key]
        [Column(Order = 1)]
        public int StudentId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "char(10)")]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        [Required(AllowEmptyStrings = true)]
        public DateTime Birthday { get; set; }

        public virtual ICollection<HomeworkSubmissions> HomeworkSubmissions { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
