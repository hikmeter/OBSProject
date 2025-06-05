using OBS.Application.Features.CQRS.Queries.FacultyQueries;
using OBS.Application.Features.CQRS.Results.FacultyResults;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.FacultyHandlers
{
    public class GetFacultyByIdQueryHandler
    {
        private readonly IRepository<Faculty> _repository;
        public GetFacultyByIdQueryHandler(IRepository<Faculty> repository)
        {
            _repository = repository;
        }
        public async Task<GetFacultyByIdQueryResult> Handle(GetFacultyByIdQuery query)
        {
            var value= await _repository.GetByIdAsync(query.Id);
            return new GetFacultyByIdQueryResult
            {
                FacultyID = value.FacultyID,
                FacultyName = value.FacultyName
            };
        }
    }
}
