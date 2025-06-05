using OBS.Application.Features.CQRS.Commands.CourseCommands;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.CourseHandlers
{
    public class CreateCourseCommandHandler
    {
        private readonly IRepository<Course> _repository;
        public CreateCourseCommandHandler(IRepository<Course> repository)
        {
            this._repository = repository;
        }
        public async Task Handle(CreateCourseCommand command)
        {
            await _repository.CreateAsync(new Course
            {
                CourseCode = command.CourseCode,
                CourseName = command.CourseName,
                Credit = command.Credit,
                DepartmentID = command.DepartmentID,
                TeacherID = command.TeacherID
            });       
        }
    }
}
