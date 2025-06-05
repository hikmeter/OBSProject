using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Queries.StudentCourseQueries
{
    public class GetStudentCoursesByStudentIdQuery
    {
        public int Id { get; set; }
        public GetStudentCoursesByStudentIdQuery(int id)
        {
            Id = id;
        }
    }
}
