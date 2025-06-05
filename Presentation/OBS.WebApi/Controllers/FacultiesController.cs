using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBS.Application.Features.CQRS.Commands.FacultyCommands;
using OBS.Application.Features.CQRS.Handlers.FacultyHandlers;
using OBS.Application.Features.CQRS.Queries.FacultyQueries;

namespace OBS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly CreateFacultyCommandHandler _createFacultyCommandHandler;
        private readonly GetFacultyByIdQueryHandler _getFacultyByIdQueryHandler;
        private readonly GetFacultyQueryHandler _getFacultyQueryHandler;
        private readonly UpdateFacultyCommandHandler _updateFacultyCommandHandler;
        private readonly RemoveFacultyCommandHandler _removeFacultyCommandHandler;
        public FacultiesController(CreateFacultyCommandHandler createFacultyCommandHandler, GetFacultyByIdQueryHandler getFacultyByIdQueryHandler, GetFacultyQueryHandler getFacultyQueryHandler, UpdateFacultyCommandHandler updateFacultyCommandHandler, RemoveFacultyCommandHandler removeFacultyCommandHandler)
        {
            _createFacultyCommandHandler = createFacultyCommandHandler;
            _getFacultyByIdQueryHandler = getFacultyByIdQueryHandler;
            _getFacultyQueryHandler = getFacultyQueryHandler;
            _updateFacultyCommandHandler = updateFacultyCommandHandler;
            _removeFacultyCommandHandler = removeFacultyCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> FacultyList()
        {
            var values = await _getFacultyQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFaculty(int id)
        {
            var value = await _getFacultyByIdQueryHandler.Handle(new GetFacultyByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFaculty(CreateFacultyCommand command)
        {
            await _createFacultyCommandHandler.Handle(command);
            return Ok("Fakülte Eklendi!");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFaculty(int id)
        {
            await _removeFacultyCommandHandler.Handle(new RemoveFacultyCommand(id));
            return Ok("Fakülte Silindi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFaculty(UpdateFacultyCommand command)
        {
            await _updateFacultyCommandHandler.Handle(command);
            return Ok("Fakülte Güncellendi!");
        }
    }
}
