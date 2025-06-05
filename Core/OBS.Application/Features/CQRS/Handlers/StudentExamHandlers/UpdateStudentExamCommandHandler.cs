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
    public class UpdateStudentExamCommandHandler
    {
        private readonly IRepository<StudentExam> _repository;
        public UpdateStudentExamCommandHandler(IRepository<StudentExam> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateStudentExamCommand command)
        {
            var value = await _repository.GetByIdAsync(command.StudentExamID);
            value.StudentExamID = command.StudentExamID;
            value.StudentID = command.StudentID;
            value.ExamID = command.ExamID;
            value.Grade = command.Grade;
            value.GradedAt = command.GradedAt;
        }
    }
}
