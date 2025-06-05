using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Results.AdvisorResults
{
    public class GetAdvisorsWithTeachersAndStudentsQueryResult
    {
        public int AdvisorID { get; set; }
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string MeetingDay { get; set; }
        public TimeSpan MeetingTime { get; set; }
    }
}
