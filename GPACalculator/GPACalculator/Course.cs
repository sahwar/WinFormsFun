using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsekOcena
{
    public class Course
    {
        public string Name { get; set; }
        public int ECTS { get; set; }
        public int Grade { get; set; }
        public  bool Passed { get; set; }
        public Course()
        {
            Name = string.Empty;
            ECTS = Grade = default(int);
            Passed = false;
        }
        
    }
}
