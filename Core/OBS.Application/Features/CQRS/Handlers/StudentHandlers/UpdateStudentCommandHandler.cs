using OBS.Application.Features.CQRS.Commands.StudentCommands;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.StudentHandlers
{
    public class UpdateStudentCommandHandler
    {
        private readonly IRepository<Student> _repository;
        public UpdateStudentCommandHandler(IRepository<Student> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateStudentCommand command)
        {
            var value = await _repository.GetByIdAsync(command.StudentID);
            value.StudentID = command.StudentID;
            value.Surname = command.Surname;
            value.Email = command.Email;
            value.BirthDate = command.BirthDate;
            value.DepartmentID = command.DepartmentID;
            value.Gender = command.Gender;
            value.Name = command.Name;
            value.Password = command.Password;
            value.StudentNo = command.StudentNo;
            await _repository.UpdateAsync(value);
        }
    }
}
