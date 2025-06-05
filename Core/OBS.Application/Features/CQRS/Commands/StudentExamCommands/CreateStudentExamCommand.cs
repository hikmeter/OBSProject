using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Commands.StudentExamCommands
{
    public class CreateStudentExamCommand
    {
        public int StudentID { get; set; }
        public int ExamID { get; set; }
        public int Grade { get; set; }
        public DateTime GradedAt { get; set; }
    }
}
