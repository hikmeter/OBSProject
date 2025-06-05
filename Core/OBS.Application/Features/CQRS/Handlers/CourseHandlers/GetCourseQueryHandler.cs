using OBS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBS.Domain.Entities;
using OBS.Application.Features.CQRS.Results.CourseResults;

namespace OBS.Application.Features.CQRS.Handlers.CourseHandlers
{
    public class GetCourseQueryHandler
    {
        private readonly IRepository<Course> _repository;
        public GetCourseQueryHandler(IRepository<Course> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCourseQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCourseQueryResult
            {
                CourseID = x.CourseID,
                CourseCode = x.CourseCode,
                CourseName = x.CourseName,
                Credit =x.Credit,
                DepartmentID = x.DepartmentID,
                TeacherID = x.TeacherID
            }).ToList();
        }
    }
}
