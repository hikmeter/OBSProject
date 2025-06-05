using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Queries.TeacherQueries
{
    public class GetTeacherByIdQuery
    {
        public int Id { get; set; }
        public GetTeacherByIdQuery(int id)
        {
            Id = id;
        }
    }
}
