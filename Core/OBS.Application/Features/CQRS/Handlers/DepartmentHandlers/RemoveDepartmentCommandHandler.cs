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
    public class RemoveDepartmentCommandHandler
    {
        private readonly IRepository<Department> _repository;
        public RemoveDepartmentCommandHandler(IRepository<Department> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveDepartmentCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
