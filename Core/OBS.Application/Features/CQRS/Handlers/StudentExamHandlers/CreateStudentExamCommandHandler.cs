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
    public class CreateStudentExamCommandHandler
    {
        private readonly IRepository<StudentExam> _repository;
        public CreateStudentExamCommandHandler(IRepository<StudentExam> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateStudentExamCommand command)
        {
            await _repository.CreateAsync(new StudentExam
            {
                ExamID = command.ExamID,
                StudentID = command.StudentID,
                GradedAt = command.GradedAt,
                Grade = command.Grade
            });
        }
    }
}
