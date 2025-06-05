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
    public class GetFacultyQueryHandler
    {
        private readonly IRepository<Faculty> _repository;
        public GetFacultyQueryHandler(IRepository<Faculty> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetFacultyQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFacultyQueryResult
            {
                FacultyID = x.FacultyID,
                FacultyName = x.FacultyName
            }).ToList();
        }
    }
}
