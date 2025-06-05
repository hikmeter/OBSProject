using OBS.Application.Features.CQRS.Queries.CourseQueries;
using OBS.Application.Features.CQRS.Results.CourseResults;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.CourseHandlers
{
    public class GetCourseByIdQueryHandler
    {
        private readonly IRepository<Course> _repository;
        public GetCourseByIdQueryHandler(IRepository<Course> repository)
        {
            _repository = repository;
        }
        public async Task<GetCourseByIdQueryResult> Handle(GetCourseByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetCourseByIdQueryResult
            {
                CourseID = value.CourseID,
                CourseCode = value.CourseCode,
                CourseName = value.CourseName,
                Credit = value.Credit,
                DepartmentID = value.DepartmentID,
                TeacherID = value.TeacherID,
            };
        }
    }
}
