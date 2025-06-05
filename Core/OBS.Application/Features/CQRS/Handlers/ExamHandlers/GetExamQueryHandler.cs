using OBS.Application.Features.CQRS.Results.ExamResults;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.ExamHandlers
{
    public class GetExamQueryHandler
    {
        private readonly IRepository<Exam> _repository;
        public GetExamQueryHandler(IRepository<Exam> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetExamQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetExamQueryResult
            {
                CourseID = x.CourseID,
                CreatedTime = x.CreatedTime,
                ExamID = x.ExamID,
                ExamName = x.ExamName,
                TeacherID = x.TeacherID,
                Weight = x.Weight
            }).ToList();
        }
    }
}
