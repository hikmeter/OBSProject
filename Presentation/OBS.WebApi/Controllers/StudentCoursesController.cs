using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBS.Application.Features.CQRS.Commands.StudentCourseCommands;
using OBS.Application.Features.CQRS.Handlers.StudentCourseHandlers;
using OBS.Application.Features.CQRS.Queries.StudentCourseQueries;

namespace OBS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        private readonly CreateStudentCourseCommandHandler _createStudentCourseCommandHandler;
        private readonly GetStudentCourseByIdQueryHandler _getStudentCourseByIdQueryHandler;
        private readonly GetStudentCourseQueryHandler _getStudentCourseQueryHandler;
        private readonly UpdateStudentCourseCommandHandler _updateStudentCourseCommandHandler;
        private readonly RemoveStudentCourseCommandHandler _removeStudentCourseCommandHandler;
        private readonly GetStudentCoursesByStudentIdQueryHandler _getStudentCoursesByStudentIdQueryHandler;
        public StudentCoursesController(CreateStudentCourseCommandHandler createStudentCourseCommandHandler, GetStudentCourseByIdQueryHandler getStudentCourseByIdQueryHandler, GetStudentCourseQueryHandler getStudentCourseQueryHandler, UpdateStudentCourseCommandHandler updateStudentCourseCommandHandler, RemoveStudentCourseCommandHandler removeStudentCourseCommandHandler, GetStudentCoursesByStudentIdQueryHandler getStudentCoursesByStudentIdQueryHandler)
        {
            _createStudentCourseCommandHandler = createStudentCourseCommandHandler;
            _getStudentCourseByIdQueryHandler = getStudentCourseByIdQueryHandler;
            _getStudentCourseQueryHandler = getStudentCourseQueryHandler;
            _updateStudentCourseCommandHandler = updateStudentCourseCommandHandler;
            _removeStudentCourseCommandHandler = removeStudentCourseCommandHandler;
            _getStudentCoursesByStudentIdQueryHandler = getStudentCoursesByStudentIdQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> StudentCourseList()
        {
            var values = await _getStudentCourseQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentCourse(int id)
        {
            var value = await _getStudentCourseByIdQueryHandler.Handle(new GetStudentCourseByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudentCourse(CreateStudentCourseCommand command)
        {
            await _createStudentCourseCommandHandler.Handle(command);
            return Ok("Öğrenci Ders Eklendi!");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveStudentCourse(int id)
        {
            await _removeStudentCourseCommandHandler.Handle(new RemoveStudentCourseCommand(id));
            return Ok("Öğrenci Ders Silindi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudentCourse(UpdateStudentCourseCommand command)
        {
            await _updateStudentCourseCommandHandler.Handle(command);
            return Ok("Öğrenci Ders Güncellendi!");
        }
        [HttpGet("GetStudentCourseWithCourseNameByStudentId")]
        public IActionResult GetStudentCourseWithCourseNameByStudentId(int id)
        {
            var values = _getStudentCoursesByStudentIdQueryHandler.Handle(new GetStudentCoursesByStudentIdQuery(id));
            return Ok(values);
        }
    }
}
