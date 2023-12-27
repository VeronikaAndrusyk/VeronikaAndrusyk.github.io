using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my5Labka.models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public string Group { get; set; }
        public string Faculty { get; set; }
        public decimal AverageGrade { get; set; }
        public string Workplace { get; set; }
        public string City { get; set; }

    }
}
