using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Domain.Entities
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public List<Exam> Exams { get; set; }
        public List<Course> Courses { get; set; }
        public List<Advisor> Advisors { get; set; }
    }
}
