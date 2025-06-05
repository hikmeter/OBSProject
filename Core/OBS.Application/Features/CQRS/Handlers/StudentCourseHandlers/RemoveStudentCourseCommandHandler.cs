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
    public class RemoveStudentCourseCommandHandler
    {
        private readonly IRepository<StudentCourse> _repository;
        public RemoveStudentCourseCommandHandler(IRepository<StudentCourse> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveStudentCourseCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
