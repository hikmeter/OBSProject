using OBS.Application.Features.CQRS.Queries.LoginQueries;
using OBS.Application.Features.CQRS.Results.LoginResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Interfaces.LoginRepositories
{
    public interface ILoginRepository
    {
        GetLoginQueryResult Login(GetLoginQuery query);
    }
}
