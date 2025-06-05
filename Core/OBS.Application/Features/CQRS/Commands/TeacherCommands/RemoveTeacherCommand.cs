using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Commands.TeacherCommands
{
    public class RemoveTeacherCommand
    {
        public int Id { get; set; }
        public RemoveTeacherCommand(int id)
        {
            Id = id;
        }
    }
}
