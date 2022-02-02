using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            Resources = new HashSet<Resource>();
            HomeworkSubmissions = new HashSet<HomeworkSubmissions>();
            StudentCourses = new HashSet<StudentCourse>();
        }
        [Key]
        public int CourseId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(80)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }

        public virtual ICollection<HomeworkSubmissions> HomeworkSubmissions { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
