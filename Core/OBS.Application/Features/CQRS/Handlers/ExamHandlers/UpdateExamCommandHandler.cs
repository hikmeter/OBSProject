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
    public class UpdateExamCommandHandler
    {
        private readonly IRepository<Exam> _repository;
        public UpdateExamCommandHandler(IRepository<Exam> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateExamCommand command)
        {
            var value = await _repository.GetByIdAsync(command.ExamID);
            value.CourseID = command.CourseID;
            value.TeacherID = command.TeacherID;
            value.ExamID = command.ExamID;
            value.CreatedTime = command.CreatedTime;
            value.ExamName = command.ExamName;
            await _repository.UpdateAsync(value);
        }
    }
}
