using OBS.Application.Features.CQRS.Queries.StudentCourseQueries;
using OBS.Application.Features.CQRS.Results.StudentCourseResults;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.StudentCourseHandlers
{
    public class GetStudentCourseByIdQueryHandler
    {
        private readonly IRepository<StudentCourse> _repository;
        public GetStudentCourseByIdQueryHandler(IRepository<StudentCourse> repository)
        {
            _repository = repository;
        }
        public async Task<GetStudentCourseByIdQueryResult> Handle(GetStudentCourseByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetStudentCourseByIdQueryResult
            {
                CourseID = value.CourseID,
                IsPassed = value.IsPassed,
                LetterGrade = value.LetterGrade,
                Semester = value.Semester,
                StudentCourseID = value.StudentCourseID,
                StudentID = value.StudentID,
            };
        }
    }
}
