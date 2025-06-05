using OBS.Application.Features.CQRS.Commands.ExamCommands;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.ExamHandlers
{
    public class RemoveExamCommandHandler
    {
        private readonly IRepository<Exam> _repository;
        public RemoveExamCommandHandler(IRepository<Exam> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveExamCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
