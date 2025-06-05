using OBS.Application.Features.CQRS.Queries.ExamQueries;
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
    public class GetExamByIdQueryHandler
    {
        private readonly IRepository<Exam> _repository;
        public GetExamByIdQueryHandler(IRepository<Exam> repository)
        {
            _repository = repository;
        }
        public async Task<GetExamByIdQueryResult> Handle(GetExamByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetExamByIdQueryResult
            {
                CourseID = value.CourseID,
                CreatedTime = value.CreatedTime,
                ExamID = value.ExamID,
                ExamName = value.ExamName,
                TeacherID = value.TeacherID,
                Weight = value.Weight
            };
        }
    }
}
