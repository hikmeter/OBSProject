using OBS.Application.Features.CQRS.Queries.TeacherQueries;
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
    public class GetTeacherByIdQueryHandler
    {
        private readonly IRepository<Teacher> _repository;
        public GetTeacherByIdQueryHandler(IRepository<Teacher> repository)
        {
            _repository = repository;
        }
        public async Task<GetTeacherByIdQueryResult> Handle(GetTeacherByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetTeacherByIdQueryResult
            {
                DepartmentID = value.DepartmentID,
                Email = value.Email,
                Name = value.Name,
                Password = value.Password,
                Surname = value.Surname,
                TeacherID = value.TeacherID,
                Title = value.Title
            };
        }
    }
}
