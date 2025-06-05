using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Domain.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
        public List<StudentExam> StudentExams { get; set; }
        public List<Advisor> Advisors { get; set; }
    }
}
