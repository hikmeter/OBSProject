using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Queries.AdvisorQueries
{
    public class GetAdvisorByIdQuery
    {
        public int Id { get; set; }
        public GetAdvisorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
