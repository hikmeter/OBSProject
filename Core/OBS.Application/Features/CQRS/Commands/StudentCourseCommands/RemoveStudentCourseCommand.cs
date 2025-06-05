using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Commands.StudentCourseCommands
{
    public class RemoveStudentCourseCommand
    {
        public int Id { get; set; }
        public RemoveStudentCourseCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
