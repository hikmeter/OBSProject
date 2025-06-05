using OBS.Application.Features.CQRS.Queries.DepartmentQueries;
using OBS.Application.Features.CQRS.Results.DepartmentResults;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.DepartmentHandlers
{
    public class GetDepartmentByIdQueryHandler
    {
        private readonly IRepository<Department> _repository;
        public GetDepartmentByIdQueryHandler(IRepository<Department> repository)
        {
            _repository = repository;
        }
        public async Task<GetDepartmentByIdQueryResult> Handle(GetDepartmentByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetDepartmentByIdQueryResult
            {
                DepartmentID = value.DepartmentID,
                DepartmentName = value.DepartmentName,
                FacultyID = value.FacultyID,
            };
        }
    }
}
