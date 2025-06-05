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
    public class UpdateTeacherCommandHandler
    {
        private readonly IRepository<Teacher> _repository;
        public UpdateTeacherCommandHandler(IRepository<Teacher> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateTeacherCommand command)
        {
            var value = await _repository.GetByIdAsync(command.TeacherID);
            value.Surname = command.Surname;
            value.TeacherID = command.TeacherID;
            value.DepartmentID = command.DepartmentID;
            value.Name = command.Name;
            value.Email = command.Email;
            value.Password = command.Password;
            value.Title = command.Title;
            await _repository.UpdateAsync(value);
        }
    }
}
