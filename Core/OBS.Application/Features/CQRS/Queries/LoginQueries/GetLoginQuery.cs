using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Queries.LoginQueries
{
    public class GetLoginQuery
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }
    }
}
