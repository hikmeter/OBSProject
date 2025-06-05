using OBS.Application.Features.CQRS.Commands.TeacherCommands;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.TeacherHandlers
{
    public class RemoveTeacherCommandHandler
    {
        private readonly IRepository<Teacher> _repository;
        public RemoveTeacherCommandHandler(IRepository<Teacher> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveTeacherCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
