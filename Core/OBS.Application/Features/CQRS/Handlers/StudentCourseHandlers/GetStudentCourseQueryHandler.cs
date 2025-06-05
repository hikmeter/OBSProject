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
    public class GetStudentCourseQueryHandler
    {
        private readonly IRepository<StudentCourse> _repository;
        public GetStudentCourseQueryHandler(IRepository<StudentCourse> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetStudentCourseQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetStudentCourseQueryResult
            {
                CourseID = x.CourseID,
                IsPassed = x.IsPassed,
                LetterGrade = x.LetterGrade,
                Semester = x.Semester,
                StudentCourseID = x.StudentCourseID,
                StudentID = x.StudentID
            }).ToList();
        }
    }
}
