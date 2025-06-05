using Microsoft.EntityFrameworkCore;
using OBS.Application.Interfaces.StudentCourseRepositories;
using OBS.Domain.Entities;
using OBSPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Persistence.Repositories.StudentCourseRepositories
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly OBSContext _context;
        public StudentCourseRepository(OBSContext context)
        {
            _context = context;
        }
        public List<StudentCourse> GetCoursesByStudentID(int studentID)
        {
            var values = _context.StudentCourses.Include(x => x.Course).Where(y => y.StudentID == studentID).ToList();
            return values;
        }
    }
}
