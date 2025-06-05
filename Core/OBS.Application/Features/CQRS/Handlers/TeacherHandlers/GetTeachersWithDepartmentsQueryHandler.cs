using OBS.Application.Features.CQRS.Results.TeacherResults;
using OBS.Application.Interfaces.TeacherRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.TeacherHandlers
{
    public class GetTeachersWithDepartmentsQueryHandler
    {
        private readonly ITeacherRepository _repository;
        public GetTeachersWithDepartmentsQueryHandler(ITeacherRepository repository)
        {
            _repository = repository;
        }
        public List<GetTeachersWithDepartmentsQueryResult> Handle()
        {
            var values = _repository.GetTeachersWithDepartments();
            return values.Select(x => new GetTeachersWithDepartmentsQueryResult
            {
                DepartmentID = x.DepartmentID,
                DepartmentName = x.Department.DepartmentName,
                Email = x.Email,
                Name = x.Name,
                Password = x.Password,
                Surname = x.Surname,
                TeacherID = x.TeacherID,
                Title = x.Title
            }).ToList();
        }
    }
}
