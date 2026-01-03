using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Entities
{
    public sealed class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public int IdJobTitle { get; set; }
        public int IdDepartment { get; set; }
        public DateOnly EmploymentDate { get; set; }
    }
}