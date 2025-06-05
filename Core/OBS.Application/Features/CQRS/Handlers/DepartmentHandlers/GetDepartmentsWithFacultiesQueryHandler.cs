using OBS.Application.Features.CQRS.Results.DepartmentResults;
using OBS.Application.Interfaces.DepartmentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.DepartmentHandlers
{
    public class GetDepartmentsWithFacultiesQueryHandler
    {
        private readonly IDepartmentRepository _repository;
        public GetDepartmentsWithFacultiesQueryHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public List<GetDepartmentsWithFacultiesQueryResult> Handle()
        {
            var values = _repository.GetDepartmentsWithFaculties();
            return values.Select(x => new GetDepartmentsWithFacultiesQueryResult
            {
                DepartmentID = x.DepartmentID,
                DepartmentName = x.DepartmentName,
                FacultyID = x.FacultyID,
                FacultyName = x.Faculty.FacultyName
            }).ToList();
        }
    }
}
