using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Commands.StudentExamCommands
{
    public class RemoveStudentExamCommand
    {
        public int Id { get; set; }
        public RemoveStudentExamCommand(int id)
        {
            Id = id;
        }
    }
}
