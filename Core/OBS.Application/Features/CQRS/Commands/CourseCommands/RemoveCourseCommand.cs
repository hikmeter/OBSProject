using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Commands.CourseCommands
{
    public class RemoveCourseCommand
    {
        public int Id { get; set; }

        public RemoveCourseCommand(int id)
        {
            Id = id;
        }
    }
}
