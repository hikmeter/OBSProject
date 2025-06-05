using OBS.Application.Features.CQRS.Commands.DepartmentCommands;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.DepartmentHandlers
{
    public class CreateDepartmentCommandHandler
    {
        private readonly IRepository<Department> _repository;
        public CreateDepartmentCommandHandler(IRepository<Department> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateDepartmentCommand command)
        {
            await _repository.CreateAsync(new Department
            {
                DepartmentName = command.DepartmentName,
                FacultyID = command.FacultyID
            });
        }
    }
}
