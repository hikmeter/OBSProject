using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Commands.FacultyCommands
{
    public class RemoveFacultyCommand
    {
        public int Id { get; set; }
        public RemoveFacultyCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
