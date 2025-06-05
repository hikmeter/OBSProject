using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Domain.Entities
{
    public class Advisor
    {
        public int AdvisorID { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public string MeetingDay { get; set; }
        public TimeSpan MeetingTime { get; set; }
    }
}
