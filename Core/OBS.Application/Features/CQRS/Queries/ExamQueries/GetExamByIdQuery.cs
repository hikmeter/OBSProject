using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Queries.ExamQueries
{
    public class GetExamByIdQuery
    {
        public int Id { get; set; }
        public GetExamByIdQuery(int id)
        {
            Id = id;
        }
    }
}
