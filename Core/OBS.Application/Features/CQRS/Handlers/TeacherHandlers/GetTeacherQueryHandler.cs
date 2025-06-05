using OBS.Application.Features.CQRS.Results.TeacherResults;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.TeacherHandlers
{
    public class GetTeacherQueryHandler
    {
        private readonly IRepository<Teacher> _repository;
        public GetTeacherQueryHandler(IRepository<Teacher> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetTeacherQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTeacherQueryResult
            {
                DepartmentID = x.DepartmentID,
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
