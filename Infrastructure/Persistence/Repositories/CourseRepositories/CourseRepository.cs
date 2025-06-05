using Microsoft.EntityFrameworkCore;
using OBS.Application.Interfaces.CourseRepositories;
using OBS.Domain.Entities;
using OBSPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Persistence.Repositories.CourseRepositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly OBSContext _context;
        public CourseRepository(OBSContext context)
        {
            _context = context;
        }
        public List<Course> GetCoursesWithDepartments()
        {
            var values = _context.Courses.Include(x => x.Department).ToList();
            return values;
        }
    }
}
