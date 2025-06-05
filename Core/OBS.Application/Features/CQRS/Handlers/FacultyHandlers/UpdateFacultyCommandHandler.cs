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
    public class UpdateFacultyCommandHandler
    {
        private readonly IRepository<Faculty> _repository;
        public UpdateFacultyCommandHandler(IRepository<Faculty> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateFacultyCommand command)
        {
            var value = await _repository.GetByIdAsync(command.FacultyID);
            value.FacultyID = command.FacultyID;
            value.FacultyName = command.FacultyName;
            await _repository.UpdateAsync(value);
        }
    }
}
