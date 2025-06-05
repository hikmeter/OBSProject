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
    public class CreateStudentCommandHandler
    {
        private readonly IRepository<Student> _repository;
        public CreateStudentCommandHandler(IRepository<Student> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateStudentCommand command)
        {
            await _repository.CreateAsync(new Student
            {
                BirthDate = command.BirthDate,
                DepartmentID = command.DepartmentID,
                Email = command.Email,
                Gender = command.Gender,
                Name = command.Name,    
                Password = command.Password,
                StudentNo = command.StudentNo,
                Surname = command.Surname
            });
        }
    }
}
