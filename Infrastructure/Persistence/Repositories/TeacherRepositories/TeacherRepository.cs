using Microsoft.EntityFrameworkCore;
using OBS.Application.Interfaces.TeacherRepositories;
using OBS.Domain.Entities;
using OBSPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Persistence.Repositories.TeacherRepositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly OBSContext _context;
        public TeacherRepository(OBSContext context)
        {
            _context = context;
        }
        public List<Teacher> GetTeachersWithDepartments()
        {
            var values = _context.Teachers.Include(x => x.Department).ToList();
            return values;
        }
    }
}
