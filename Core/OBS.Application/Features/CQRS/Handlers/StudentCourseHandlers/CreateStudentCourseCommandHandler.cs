using OBS.Application.Features.CQRS.Commands.StudentCourseCommands;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.StudentCourseHandlers
{
    public class CreateStudentCourseCommandHandler
    {
        private readonly IRepository<StudentCourse> _repository;
        public CreateStudentCourseCommandHandler(IRepository<StudentCourse> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateStudentCourseCommand command)
        {
            await _repository.CreateAsync(new StudentCourse
            {
                CourseID = command.CourseID,
                IsPassed = command.IsPassed,
                LetterGrade = command.LetterGrade,
                Semester = command.Semester,
                StudentID = command.StudentID
            });
        }
    }
}
