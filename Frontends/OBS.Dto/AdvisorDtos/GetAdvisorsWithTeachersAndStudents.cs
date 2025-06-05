using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Dto.AdvisorDtos
{
    public class GetAdvisorsWithTeachersAndStudents
    {
        public int advisorID { get; set; }
        public int teacherID { get; set; }
        public string teacherName { get; set; }
        public string teacherSurname { get; set; }
        public int studentID { get; set; }
        public string studentName { get; set; }
        public string studentSurname { get; set; }
        public string meetingDay { get; set; }
        public string meetingTime { get; set; }
    }
}
