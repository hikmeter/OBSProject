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
    public class UpdateDepartmentCommandHandler
    {
        private readonly IRepository<Department> _repository;
        public UpdateDepartmentCommandHandler(IRepository<Department> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateDepartmentCommand command)
        {
            var value= await _repository.GetByIdAsync(command.DepartmentID);
            value.DepartmentID=command.DepartmentID;
            value.DepartmentName=command.DepartmentName;
            value.FacultyID=command.FacultyID;
            await _repository.UpdateAsync(value);
        }
    }
}
