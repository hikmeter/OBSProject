using OBS.Application.Features.CQRS.Results.CourseResults;
using OBS.Application.Interfaces.CourseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.CourseHandlers
{
    public class GetCoursesWithDepartmentsQueryHandler
    {
        private readonly ICourseRepository _repository;
        public GetCoursesWithDepartmentsQueryHandler(ICourseRepository repository)
        {
            _repository = repository;
        }
        public List<GetCoursesWithDepartmentsQueryResult> Handle()
        {
            var values = _repository.GetCoursesWithDepartments();
            return values.Select(x => new GetCoursesWithDepartmentsQueryResult
            {
                CourseCode = x.CourseCode,
                CourseID = x.CourseID,
                CourseName = x.CourseName,
                Credit = x.Credit,
                DepartmentID = x.DepartmentID,
                DepartmentName = x.Department.DepartmentName,
                TeacherID = x.TeacherID
            }).ToList();
        }
    }
}
