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
    public class UpdateAdvisorCommandHandler
    {
        private readonly IRepository<Advisor> _repository;
        public UpdateAdvisorCommandHandler(IRepository<Advisor> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAdvisorCommand command)
        {
            var value = await _repository.GetByIdAsync(command.AdvisorID);
            value.AdvisorID = command.AdvisorID;
            value.TeacherID = command.TeacherID;
            value.StudentID = command.StudentID;
            value.MeetingDay = command.MeetingDay;
            value.MeetingTime = command.MeetingTime;
            await _repository.UpdateAsync(value);
        }
    }
}
