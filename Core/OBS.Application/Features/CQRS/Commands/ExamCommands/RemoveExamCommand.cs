using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Commands.ExamCommands
{
    public class RemoveExamCommand
    {
        public int Id { get; set; }
        public RemoveExamCommand(int id)
        {
            Id = id;
        }
    }
}
