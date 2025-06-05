using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Queries.DepartmentQueries
{
    public class GetDepartmentByIdQuery
    {
        public GetDepartmentByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
