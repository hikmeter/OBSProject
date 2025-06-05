using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Dto.ExamDtos
{
    public class GetExamsWithCoursesAndTeachersDto
    {
        public int examID { get; set; }
        public int courseID { get; set; }
        public string courseName { get; set; }
        public int teacherID { get; set; }
        public string teacherName { get; set; }
        public string teacherSurname { get; set; }
        public string examName { get; set; }
        public int weight { get; set; }
        public DateTime createdTime { get; set; }
    }
}
