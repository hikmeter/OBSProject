using Microsoft.EntityFrameworkCore;
using OBS.Application.Interfaces.AdvisorRepositories;
using OBS.Domain.Entities;
using OBSPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Persistence.Repositories.AdvisorRepositories
{
    public class AdvisorRepository : IAdvisorRepository
    {
        private readonly OBSContext _context;
        public AdvisorRepository(OBSContext context)
        {
            _context = context;
        }
        public List<Advisor> GetAdvisorsWithTeachersAndStudents()
        {
            var values = _context.Advisors.Include(x => x.Teacher).Include(y => y.Student).ToList();
            return values;
        }
    }
}
