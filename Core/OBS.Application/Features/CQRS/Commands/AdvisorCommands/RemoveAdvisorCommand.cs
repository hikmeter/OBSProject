using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Commands.AdvisorCommands
{
    public class RemoveAdvisorCommand
    {
        public int Id { get; set; }
        public RemoveAdvisorCommand(int id)
        {
            Id = id;
        }
    }
}
