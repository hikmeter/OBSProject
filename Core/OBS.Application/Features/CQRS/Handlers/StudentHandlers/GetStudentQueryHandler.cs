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
    public class GetStudentQueryHandler
    {
        private readonly IRepository<Student> _repository;
        public GetStudentQueryHandler(IRepository<Student> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetStudentQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetStudentQueryResult
            {
                StudentID = x.StudentID,
                BirthDate = x.BirthDate,
                DepartmentID = x.DepartmentID,
                Email = x.Email,
                Gender = x.Gender,
                Name = x.Name,
                Password = x.Password,
                StudentNo = x.StudentNo,    
                Surname = x.Surname
            }).ToList();
        }
    }
}
