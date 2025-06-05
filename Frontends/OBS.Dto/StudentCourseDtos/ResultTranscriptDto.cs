using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Dto.StudentCourseDtos
{
    public class ResultTranscriptDto
    {
        public int studentCourseID { get; set; }
        public int studentID { get; set; }
        public int courseID { get; set; }
        public string courseName { get; set; }
        public string courseCode { get; set; }
        public int credit { get; set; }
        public string semester { get; set; }
        public bool isPassed { get; set; }
        public string letterGrade { get; set; }
    }
}
