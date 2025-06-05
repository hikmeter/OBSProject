using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Commands.AdvisorCommands
{
    public class UpdateAdvisorCommand
    {
        public int AdvisorID { get; set; }
        public int TeacherID { get; set; }
        public int StudentID { get; set; }
        public string MeetingDay { get; set; }
        public TimeSpan MeetingTime { get; set; }
    }
}
