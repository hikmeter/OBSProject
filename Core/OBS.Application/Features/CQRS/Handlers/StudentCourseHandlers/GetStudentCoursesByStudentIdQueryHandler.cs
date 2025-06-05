using OBS.Application.Features.CQRS.Queries.StudentCourseQueries;
using OBS.Application.Features.CQRS.Results.StudentCourseResults;
using OBS.Application.Interfaces.StudentCourseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.StudentCourseHandlers
{
    public class GetStudentCoursesByStudentIdQueryHandler
    {
        private readonly IStudentCourseRepository _repository;
        public GetStudentCoursesByStudentIdQueryHandler(IStudentCourseRepository repository)
        {
            _repository = repository;
        }
        public List<GetStudentCoursesByStudentIdQueryResult> Handle(GetStudentCoursesByStudentIdQuery query)
        {
            var values = _repository.GetCoursesByStudentID(query.Id);
            return values.Select(x => new GetStudentCoursesByStudentIdQueryResult
            {
                CourseID = x.CourseID,
                CourseName = x.Course.CourseName,
                IsPassed = x.IsPassed,
                LetterGrade = x.LetterGrade,    
                Semester = x.Semester,
                StudentCourseID = x.StudentCourseID,
                StudentID = x.StudentID,
                CourseCode = x.Course.CourseCode,
                Credit = x.Course.Credit
            }).ToList();
        }

    }
}
