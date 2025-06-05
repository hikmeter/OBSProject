using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBS.Application.Features.CQRS.Commands.TeacherCommands;
using OBS.Application.Features.CQRS.Handlers.TeacherHandlers;
using OBS.Application.Features.CQRS.Queries.TeacherQueries;

namespace OBS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly CreateTeacherCommandHandler _createTeacherCommandHandler;
        private readonly GetTeacherByIdQueryHandler _getTeacherByIdQueryHandler;
        private readonly GetTeacherQueryHandler _getTeacherQueryHandler;
        private readonly UpdateTeacherCommandHandler _updateTeacherCommandHandler;
        private readonly RemoveTeacherCommandHandler _removeTeacherCommandHandler;
        private readonly GetTeachersWithDepartmentsQueryHandler _getTeachersWithDepartmentsQueryHandler;
        public TeachersController(CreateTeacherCommandHandler createTeacherCommandHandler, GetTeacherByIdQueryHandler getTeacherByIdQueryHandler, GetTeacherQueryHandler getTeacherQueryHandler, UpdateTeacherCommandHandler updateTeacherCommandHandler, RemoveTeacherCommandHandler removeTeacherCommandHandler, GetTeachersWithDepartmentsQueryHandler getTeachersWithDepartmentsQueryHandler)
        {
            _createTeacherCommandHandler = createTeacherCommandHandler;
            _getTeacherByIdQueryHandler = getTeacherByIdQueryHandler;
            _getTeacherQueryHandler = getTeacherQueryHandler;
            _updateTeacherCommandHandler = updateTeacherCommandHandler;
            _removeTeacherCommandHandler = removeTeacherCommandHandler;
            _getTeachersWithDepartmentsQueryHandler = getTeachersWithDepartmentsQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> TeacherList()
        {
            var values = await _getTeacherQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var value = await _getTeacherByIdQueryHandler.Handle(new GetTeacherByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeacher(CreateTeacherCommand command)
        {
            await _createTeacherCommandHandler.Handle(command);
            return Ok("Öğretim Üyesi Eklendi!");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTeacher(int id)
        {
            await _removeTeacherCommandHandler.Handle(new RemoveTeacherCommand(id));
            return Ok("Öğretim Üyesi Silindi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTeacher(UpdateTeacherCommand command)
        {
            await _updateTeacherCommandHandler.Handle(command);
            return Ok("Öğretim Üyesi Güncellendi!");
        }
        [HttpGet("GetTeacherWithDepartment")]
        public IActionResult GetTeacherWithDepartment()
        {
            var values = _getTeachersWithDepartmentsQueryHandler.Handle();
            return Ok(values);
        }
    }
}
