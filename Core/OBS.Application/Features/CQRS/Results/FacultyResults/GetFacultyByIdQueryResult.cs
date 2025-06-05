using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Results.FacultyResults
{
    public class GetFacultyByIdQueryResult
    {
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }
    }
}
