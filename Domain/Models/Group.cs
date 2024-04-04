using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Group
    {
        public int Id { get; set; }
        public required string GroupName { get; set; }
        public string? GroupDescription { get; set; }
        public int CourseId { get; set; }
    }
}
