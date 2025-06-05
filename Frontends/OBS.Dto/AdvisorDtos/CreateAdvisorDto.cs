using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Dto.AdvisorDtos
{
    public class CreateAdvisorDto
    {
        public int teacherID { get; set; }
        public int studentID { get; set; }
        public string meetingDay { get; set; }
        public string meetingTime { get; set; }
    }
}
