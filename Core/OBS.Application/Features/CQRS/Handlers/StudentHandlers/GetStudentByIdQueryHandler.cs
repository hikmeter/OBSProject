using OBS.Application.Features.CQRS.Queries.StudentQueries;
using OBS.Application.Features.CQRS.Results.StudentResults;
using OBS.Application.Interfaces;
using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Handlers.StudentHandlers
{
    public class GetStudentByIdQueryHandler
    {
        private readonly IRepository<Student> _repository;
        public GetStudentByIdQueryHandler(IRepository<Student> repository)
        {
            _repository = repository;
        }
        public async Task<GetStudentByIdQueryResult> Handle(GetStudentByIdQuery query)
        {
            var value= await _repository.GetByIdAsync(query.Id);
            return new GetStudentByIdQueryResult
            {
                StudentID = value.StudentID,
                BirthDate = value.BirthDate,
                DepartmentID = value.DepartmentID,
                Email = value.Email,
                Gender = value.Gender,
                Name = value.Name,
                Password = value.Password,
                Surname = value.Surname,
                StudentNo = value.StudentNo
            };
        }
    }
}
