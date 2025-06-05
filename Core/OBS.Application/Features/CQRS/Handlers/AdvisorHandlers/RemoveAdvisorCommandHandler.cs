using OBS.Application.Features.CQRS.Commands.AdvisorCommands;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.AdvisorHandlers
{
    public class RemoveAdvisorCommandHandler
    {
        private readonly IRepository<Advisor> _repository;
        public RemoveAdvisorCommandHandler(IRepository<Advisor> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAdvisorCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
