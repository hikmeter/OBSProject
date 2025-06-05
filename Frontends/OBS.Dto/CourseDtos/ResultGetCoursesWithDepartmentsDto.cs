using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Dto.CourseDtos
{
    public class ResultGetCoursesWithDepartmentsDto
    {
        public int courseID { get; set; }
        public string courseCode { get; set; }
        public string courseName { get; set; }
        public int credit { get; set; }
        public int departmentID { get; set; }
        public string departmentName { get; set; }
        public int teacherID { get; set; }
    }
}
