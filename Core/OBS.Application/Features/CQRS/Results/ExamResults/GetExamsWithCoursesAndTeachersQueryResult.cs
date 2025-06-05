using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Results.ExamResults
{
    public class GetExamsWithCoursesAndTeachersQueryResult
    {
        public int ExamID { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public string ExamName { get; set; }
        public int Weight { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
