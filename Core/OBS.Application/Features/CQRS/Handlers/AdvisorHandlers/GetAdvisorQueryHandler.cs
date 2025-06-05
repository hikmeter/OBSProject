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
    public class GetAdvisorQueryHandler
    {
        private readonly IRepository<Advisor> _repository;
        public GetAdvisorQueryHandler(IRepository<Advisor> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAdvisorQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAdvisorQueryResult
            {
                AdvisorID = x.AdvisorID,
                MeetingDay = x.MeetingDay,
                MeetingTime = x.MeetingTime,
                StudentID = x.StudentID,
                TeacherID = x.TeacherID
            }).ToList();
        }
    }
}
