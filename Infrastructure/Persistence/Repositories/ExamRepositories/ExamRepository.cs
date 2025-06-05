using Microsoft.EntityFrameworkCore;
using OBS.Application.Interfaces.ExamRepositories;
using OBS.Domain.Entities;
using OBSPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Persistence.Repositories.ExamRepositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly OBSContext _context;
        public ExamRepository(OBSContext context)
        {
            _context = context;
        }
        public List<Exam> GetExamsWithCoursesAndTeachers()
        {
            var values = _context.Exams.Include(x => x.Teacher).ThenInclude(y => y.Courses).ToList();
            return values;
        }
    }
}
