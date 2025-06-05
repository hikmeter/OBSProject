using OBS.Application.Features.CQRS.Commands.StudentCommands;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.StudentHandlers
{
    public class RemoveStudentCommandHandler
    {
        private readonly IRepository<Student> _repository;
        public RemoveStudentCommandHandler(IRepository<Student> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveStudentCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
