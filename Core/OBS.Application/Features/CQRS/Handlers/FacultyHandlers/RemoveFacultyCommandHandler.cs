using OBS.Application.Features.CQRS.Commands.FacultyCommands;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.FacultyHandlers
{
    public class RemoveFacultyCommandHandler
    {
        private readonly IRepository<Faculty> _repository;
        public RemoveFacultyCommandHandler(IRepository<Faculty> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveFacultyCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
