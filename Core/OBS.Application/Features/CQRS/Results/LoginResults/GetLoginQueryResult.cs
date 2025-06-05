using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Results.LoginResults
{
    public class GetLoginQueryResult
    {
        public bool Success { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
    }
}
