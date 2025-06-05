using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Queries.StudentExamQueries
{
    public class GetStudentExamByIdQuery
    {
        public int Id { get; set; }
        public GetStudentExamByIdQuery(int id)
        {
            Id = id;
        }
    }
}
