using OBS.Application.Features.CQRS.Commands.TeacherCommands;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.TeacherHandlers
{
    public class CreateTeacherCommandHandler
    {
        private readonly IRepository<Teacher> _repository;
        public CreateTeacherCommandHandler(IRepository<Teacher> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateTeacherCommand command)
        {
            await _repository.CreateAsync(new Teacher
            {
                DepartmentID = command.DepartmentID,
                Email = command.Email,
                Name = command.Name,
                Password = command.Password,
                Surname = command.Surname,
                Title = command.Title
            });
        }
    }
}
