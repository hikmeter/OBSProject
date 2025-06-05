using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Domain.Entities
{
    public class StudentCourse
    {
        public int StudentCourseID { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public string Semester { get; set; }
        public bool IsPassed { get; set; }
        public string LetterGrade { get; set; }
    }
}
