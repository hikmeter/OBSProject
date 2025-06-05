using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBS.Application.Features.CQRS.Handlers.LoginHandlers;
using OBS.Application.Features.CQRS.Queries.LoginQueries;

namespace OBS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly GetLoginQueryHandler _getLoginQueryHandler;
        public LoginsController(GetLoginQueryHandler getLoginQueryHandler)
        {
            _getLoginQueryHandler = getLoginQueryHandler;
        }
        [HttpPost]
        public IActionResult Login([FromBody] GetLoginQuery query)
        {
            if (query == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = _getLoginQueryHandler.Handle(query); 

            if (result.Success)
            {
                return Ok(new { message = $"Hoş geldiniz, {result.FullName}!", role = result.Role });
            }
            else
            {
                return Unauthorized("Geçersiz kullanıcı adı veya şifre.");
            }
        }
    }
}
