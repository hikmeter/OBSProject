using OBS.Application.Features.CQRS.Commands.StudentExamCommands;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.StudentExamHandlers
{
    public class RemoveStudentExamCommandHandler
    {
        private readonly IRepository<StudentExam> _repository;
        public RemoveStudentExamCommandHandler(IRepository<StudentExam> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveStudentExamCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
