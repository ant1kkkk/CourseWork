using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Entities
{
    public sealed class Jobtitle
    {
        public int IdJobTitle { get; set; }
        public string JobTitleName { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}