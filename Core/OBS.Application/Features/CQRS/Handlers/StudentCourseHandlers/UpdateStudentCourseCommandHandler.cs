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
    public class UpdateStudentCourseCommandHandler
    {
        private readonly IRepository<StudentCourse> _repository;
        public UpdateStudentCourseCommandHandler(IRepository<StudentCourse> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateStudentCourseCommand command)
        {
            var value = await _repository.GetByIdAsync(command.StudentCourseID);
            value.StudentCourseID = command.StudentCourseID;
            value.CourseID = command.CourseID;
            value.StudentID = command.StudentID;
            value.IsPassed = command.IsPassed;
            value.LetterGrade = command.LetterGrade;
            value.Semester = command.Semester;
            await _repository.UpdateAsync(value);
        }
    }
}
