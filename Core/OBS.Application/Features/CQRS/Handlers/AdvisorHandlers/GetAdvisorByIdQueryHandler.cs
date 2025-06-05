using OBS.Application.Features.CQRS.Queries.AdvisorQueries;
using OBS.Application.Features.CQRS.Results.AdvisorResults;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.AdvisorHandlers
{
    public class GetAdvisorByIdQueryHandler
    {
        private readonly IRepository<Advisor> _repository;
        public GetAdvisorByIdQueryHandler(IRepository<Advisor> repository)
        {
            _repository = repository;
        }
        public async Task<GetAdvisorByIdQueryResult> Handle(GetAdvisorByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetAdvisorByIdQueryResult
            {
                AdvisorID = value.AdvisorID,
                MeetingDay = value.MeetingDay,
                MeetingTime = value.MeetingTime,
                StudentID = value.StudentID,
                TeacherID = value.TeacherID
            };
        }
    }
}
