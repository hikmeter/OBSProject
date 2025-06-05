using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Domain.Entities
{
    public class Faculty
    {
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }
        public List<Department> Departments { get; set; }   
    }
}
