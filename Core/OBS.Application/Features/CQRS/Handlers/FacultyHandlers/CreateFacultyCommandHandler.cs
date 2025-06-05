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
    public class CreateFacultyCommandHandler
    {
        private readonly IRepository<Faculty> _repository;
        public CreateFacultyCommandHandler(IRepository<Faculty> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateFacultyCommand command)
        {
            await _repository.CreateAsync(new Faculty
            {
                FacultyName = command.FacultyName
            });
        }
    }
}
