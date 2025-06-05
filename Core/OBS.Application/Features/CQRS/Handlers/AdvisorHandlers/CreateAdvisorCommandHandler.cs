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
    public class CreateAdvisorCommandHandler
    {
        private readonly IRepository<Advisor> _repository;
        public CreateAdvisorCommandHandler(IRepository<Advisor> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAdvisorCommand command)
        {
            await _repository.CreateAsync(new Advisor
            {
                MeetingDay = command.MeetingDay,
                MeetingTime = command.MeetingTime,
                StudentID = command.StudentID,
                TeacherID = command.TeacherID,
            });
        }
    }
}
