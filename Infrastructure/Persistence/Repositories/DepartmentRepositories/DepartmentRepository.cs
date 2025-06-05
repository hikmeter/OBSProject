using Microsoft.EntityFrameworkCore;
using OBS.Application.Interfaces.DepartmentRepositories;
using OBS.Domain.Entities;
using OBSPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Persistence.Repositories.DepartmentRepositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly OBSContext _context;
        public DepartmentRepository(OBSContext context)
        {
            _context = context;
        }
        public List<Department> GetDepartmentsWithFaculties()
        {
            var values = _context.Departments.Include(x => x.Faculty).ToList();
            return values;
        }
    }
}
