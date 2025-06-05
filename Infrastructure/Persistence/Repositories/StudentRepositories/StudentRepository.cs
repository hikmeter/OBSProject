using Microsoft.EntityFrameworkCore;
using OBS.Application.Interfaces.StudentRepositories;
using OBS.Domain.Entities;
using OBSPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Persistence.Repositories.StudentRepositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly OBSContext _context;
        public StudentRepository(OBSContext context)
        {
            _context = context;
        }
        public List<Student> GetStudentsWithDepartments()
        {
            var values = _context.Students.Include(x => x.Department).ToList();
            return values;
        }
    }
}
