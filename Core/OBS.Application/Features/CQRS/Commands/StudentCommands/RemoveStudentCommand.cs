using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Commands.StudentCommands
{
    public class RemoveStudentCommand
    {
        public int Id { get; set; }
        public RemoveStudentCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
