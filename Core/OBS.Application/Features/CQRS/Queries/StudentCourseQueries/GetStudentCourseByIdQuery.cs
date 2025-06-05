using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Queries.StudentCourseQueries
{
    public class GetStudentCourseByIdQuery
    {
        public int Id { get; set; }
        public GetStudentCourseByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
