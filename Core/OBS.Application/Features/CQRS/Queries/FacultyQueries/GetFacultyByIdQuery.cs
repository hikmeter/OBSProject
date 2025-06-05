using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Queries.FacultyQueries
{
    public class GetFacultyByIdQuery
    {
        public int Id { get; set; }
        public GetFacultyByIdQuery(int id)
        {
            Id = id;
        }
    }
}
