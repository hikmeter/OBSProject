using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBS.Application.Features.CQRS.Commands.AdvisorCommands;
using OBS.Application.Features.CQRS.Handlers.AdvisorHandlers;
using OBS.Application.Features.CQRS.Queries.AdvisorQueries;

namespace OBS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisorsController : ControllerBase
    {
        private readonly CreateAdvisorCommandHandler _createAdvisorCommandHandler;
        private readonly GetAdvisorByIdQueryHandler _getAdvisorByIdQueryHandler;
        private readonly GetAdvisorQueryHandler _getAdvisorQueryHandler;
        private readonly UpdateAdvisorCommandHandler _updateAdvisorCommandHandler;
        private readonly RemoveAdvisorCommandHandler _removeAdvisorCommandHandler;
        private readonly GetAdvisorsWithTeachersAndStudentsQueryHandler _getAdvisorsWithTeachersAndStudentsQueryHandler;
        public AdvisorsController(CreateAdvisorCommandHandler createAdvisorCommandHandler, GetAdvisorByIdQueryHandler getAdvisorByIdQueryHandler, GetAdvisorQueryHandler getAdvisorQueryHandler, UpdateAdvisorCommandHandler updateAdvisorCommandHandler, RemoveAdvisorCommandHandler removeAdvisorCommandHandler, GetAdvisorsWithTeachersAndStudentsQueryHandler getAdvisorsWithTeachersAndStudentsQueryHandler)
        {
            _createAdvisorCommandHandler = createAdvisorCommandHandler;
            _getAdvisorByIdQueryHandler = getAdvisorByIdQueryHandler;
            _getAdvisorQueryHandler = getAdvisorQueryHandler;
            _updateAdvisorCommandHandler = updateAdvisorCommandHandler;
            _removeAdvisorCommandHandler = removeAdvisorCommandHandler;
            _getAdvisorsWithTeachersAndStudentsQueryHandler = getAdvisorsWithTeachersAndStudentsQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AdvisorList()
        {
            var values = await _getAdvisorQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdvisor(int id)
        {
            var value = await _getAdvisorByIdQueryHandler.Handle(new GetAdvisorByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdvisor(CreateAdvisorCommand command)
        {
            await _createAdvisorCommandHandler.Handle(command);
            return Ok("Danışmanlık Eklendi!");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAdvisor(int id)
        {
            await _removeAdvisorCommandHandler.Handle(new RemoveAdvisorCommand(id));
            return Ok("Danışmanlık Silindi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdvisor(UpdateAdvisorCommand command)
        {
            await _updateAdvisorCommandHandler.Handle(command);
            return Ok("Danışmanlık Güncellendi!");
        }
        [HttpGet("GetAdvisorWithTeacherAndStudent")]
        public IActionResult GetAdvisorWithTeacherAndStudent()
        {
            var values = _getAdvisorsWithTeachersAndStudentsQueryHandler.Handle();
            return Ok(values);
        }
    }
}
