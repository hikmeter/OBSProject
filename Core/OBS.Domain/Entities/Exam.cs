using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Domain.Entities
{
    public class Exam
    {
        public int ExamID { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public string ExamName { get; set; }
        public int Weight { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<StudentExam> StudentExams { get; set; }
    }
}
