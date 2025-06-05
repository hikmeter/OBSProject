using Microsoft.AspNetCore.Http;
using OBS.Application.Features.CQRS.Queries.LoginQueries;
using OBS.Application.Features.CQRS.Results.LoginResults;
using OBS.Application.Interfaces.LoginRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;


namespace OBS.Application.Features.CQRS.Handlers.LoginHandlers
{
    public class GetLoginQueryHandler
    {
        private readonly ILoginRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetLoginQueryHandler(ILoginRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }
        public GetLoginQueryResult Handle(GetLoginQuery query)
        {
            var result = _repository.Login(query);

            if (result.Success)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, result.FullName),
                    new Claim(ClaimTypes.Role, result.Role)
                };

                var identity = new ClaimsIdentity(claims, "Login");
                var principal = new ClaimsPrincipal(identity);

                _httpContextAccessor.HttpContext.SignInAsync(principal).Wait();
            }

            return result;
        }
    }
}