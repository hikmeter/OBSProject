using OBS.Application.Features.CQRS.Results.StudentExamResults;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.StudentExamHandlers
{
    public class GetStudentExamQueryHandler
    {
        private readonly IRepository<StudentExam> _repository;
        public GetStudentExamQueryHandler(IRepository<StudentExam> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetStudentExamQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetStudentExamQueryResult
            {
                ExamID = x.ExamID,
                Grade = x.Grade,
                GradedAt = x.GradedAt,
                StudentExamID = x.StudentExamID,
                StudentID = x.StudentID
            }).ToList();
        }
    }
}
