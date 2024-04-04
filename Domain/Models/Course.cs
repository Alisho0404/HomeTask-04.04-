using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Course
    {
        public int Id { get; set; }
        public required string CourseName { get; set; }
        public string? CourseDescription { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StudentLimit { get; set; }
    }
}
