using OBS.Application.Features.CQRS.Queries.StudentExamQueries;
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
    public class GetStudentExamByIdQueryHandler
    {
        private readonly IRepository<StudentExam> _repository;
        public GetStudentExamByIdQueryHandler(IRepository<StudentExam> repository)
        {
            _repository = repository;
        }
        public async Task<GetStudentExamByIdQueryResult> Handle(GetStudentExamByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetStudentExamByIdQueryResult
            {
                ExamID = value.ExamID,
                Grade = value.Grade,
                StudentExamID = value.StudentExamID,
                GradedAt = value.GradedAt,
                StudentID = value.StudentID
            };
        }
    }
}
