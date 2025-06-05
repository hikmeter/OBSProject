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
    public class CreateExamCommandHandler
    {
        private readonly IRepository<Exam> _repository;
        public CreateExamCommandHandler(IRepository<Exam> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateExamCommand command)
        {
            await _repository.CreateAsync(new Exam
            {
                CourseID = command.CourseID,
                ExamName = command.ExamName,
                TeacherID = command.TeacherID,
                Weight = command.Weight,
                CreatedTime = command.CreatedTime
            });
        }
    }
}
