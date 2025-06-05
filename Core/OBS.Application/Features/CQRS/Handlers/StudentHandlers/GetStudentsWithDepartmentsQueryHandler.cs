using OBS.Application.Features.CQRS.Results.StudentResults;
using OBS.Application.Interfaces.StudentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.StudentHandlers
{
    public class GetStudentsWithDepartmentsQueryHandler
    {
        private readonly IStudentRepository _repository;
        public GetStudentsWithDepartmentsQueryHandler(IStudentRepository repository)
        {
            _repository = repository;
        }
        public List<GetStudentsWithDepartmentsQueryResult> Handle()
        {
            var values = _repository.GetStudentsWithDepartments();
            return values.Select(x => new GetStudentsWithDepartmentsQueryResult
            {
                BirthDate = x.BirthDate,
                DepartmentID = x.DepartmentID,
                DepartmentName = x.Department.DepartmentName,
                Email = x.Email,
                Gender = x.Gender,
                Name = x.Name,
                Password = x.Password,
                StudentID = x.StudentID,
                StudentNo = x.StudentNo,
                Surname = x.Surname
            }).ToList();
        }
    }
}
