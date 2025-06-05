using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Commands.ExamCommands
{
    public class CreateExamCommand
    {
        public int CourseID { get; set; }
        public int TeacherID { get; set; }
        public string ExamName { get; set; }
        public int Weight { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
