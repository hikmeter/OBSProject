using OBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Results.DepartmentResults
{
    public class GetDepartmentQueryResult
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int FacultyID { get; set; }
    }
}
