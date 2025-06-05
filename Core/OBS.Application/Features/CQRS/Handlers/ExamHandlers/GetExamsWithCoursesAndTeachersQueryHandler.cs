using OBS.Application.Features.CQRS.Results.ExamResults;
using OBS.Application.Interfaces.ExamRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.ExamHandlers
{
    public class GetExamsWithCoursesAndTeachersQueryHandler
    {
        private readonly IExamRepository _repository;
        public GetExamsWithCoursesAndTeachersQueryHandler(IExamRepository repository)
        {
            _repository = repository;
        }
        public List<GetExamsWithCoursesAndTeachersQueryResult> Handle()
        {
            var values = _repository.GetExamsWithCoursesAndTeachers();
            return values.Select(x => new GetExamsWithCoursesAndTeachersQueryResult
            {
                CourseID = x.CourseID,
                CourseName = x.Course.CourseName,
                CreatedTime = x.CreatedTime,
                ExamName = x.ExamName,
                ExamID = x.ExamID,
                TeacherID = x.TeacherID,
                TeacherName = x.Teacher.Name,
                TeacherSurname = x.Teacher.Surname,
                Weight = x.Weight
            }).ToList();
        }
    }
}
