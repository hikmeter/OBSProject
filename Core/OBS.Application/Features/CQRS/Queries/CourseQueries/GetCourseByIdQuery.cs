using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Queries.CourseQueries
{
    public class GetCourseByIdQuery
    {
        public GetCourseByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
