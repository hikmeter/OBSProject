using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Commands.DepartmentCommands
{
    public class RemoveDepartmentCommand
    {
        public int Id { get; set; }
        public RemoveDepartmentCommand(int id)
        {
            Id = id;
        }
    }
}
