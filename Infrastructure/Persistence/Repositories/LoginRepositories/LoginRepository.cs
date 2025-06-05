using OBS.Application.Features.CQRS.Queries.LoginQueries;
using OBS.Application.Features.CQRS.Results.LoginResults;
using OBS.Application.Interfaces.LoginRepositories;
using OBSPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Persistence.Repositories.LoginRepositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly OBSContext _context;
        public LoginRepository(OBSContext context)
        {
            _context = context;
        }
        public GetLoginQueryResult Login(GetLoginQuery query)
        {
            var admin = _context.Admins.FirstOrDefault(x => x.Username == query.EmailOrUsername && x.Password == query.Password);
            if (admin != null)
            {
                return new GetLoginQueryResult
                {
                    Success = true,
                    Role = "Admin",
                    FullName = admin.Username
                };
            }
            var teacher = _context.Teachers.FirstOrDefault(x => x.Email == query.EmailOrUsername && x.Password == query.Password);
            if (teacher != null)
            {
                return new GetLoginQueryResult
                {
                    Success = true,
                    Role = "Teacher",
                    FullName = teacher.Name + " " + teacher.Surname
                };
            }
            var student = _context.Students.FirstOrDefault(x => x.Email == query.EmailOrUsername && x.Password == query.Password);
            if (student != null)
            {
                return new GetLoginQueryResult
                {
                    Success = true,
                    Role = "Student",
                    FullName = student.Name + " " + student.Surname
                };
            }
            return new GetLoginQueryResult
            {
                Success = false,
                Role = null,
                FullName = null
            };
        }
    }
}
