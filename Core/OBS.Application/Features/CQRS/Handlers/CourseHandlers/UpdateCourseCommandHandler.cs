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
    public class UpdateCourseCommandHandler
    {
        private readonly IRepository<Course> _repository;
        public UpdateCourseCommandHandler(IRepository<Course> repository)
        {
            _repository = repository;
        }
        public async Task Handle (UpdateCourseCommand command)
        {
            var values= await _repository.GetByIdAsync(command.CourseID);
            values.CourseName = command.CourseName;
            values.TeacherID = command.TeacherID;
            values.CourseCode = command.CourseCode;
            values.Credit = command.Credit;
            await _repository.UpdateAsync(values);
        }
    }
}
