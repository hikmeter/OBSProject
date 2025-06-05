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
    public class GetDepartmentQueryHandler
    {
        private readonly IRepository<Department> _repository;
        public GetDepartmentQueryHandler(IRepository<Department> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetDepartmentQueryResult>> Handle()
        {
            var values= await _repository.GetAllAsync();
            return values.Select(x=> new GetDepartmentQueryResult
            {
                DepartmentID = x.DepartmentID,
                DepartmentName = x.DepartmentName,
                FacultyID = x.FacultyID
            }).ToList();    
        }
    }
}
