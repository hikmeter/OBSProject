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
    public class RemoveCourseCommandHandler
    {
        private readonly IRepository<Course> _repository;
        public RemoveCourseCommandHandler(IRepository<Course> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCourseCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);   
        }
    }
}
