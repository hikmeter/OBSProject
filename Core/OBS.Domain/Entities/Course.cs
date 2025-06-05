using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Domain.Entities
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int Credit {  get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
