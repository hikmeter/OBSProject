using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBS.Application.Features.CQRS.Commands.CourseCommands;
using OBS.Application.Features.CQRS.Handlers.CourseHandlers;
using OBS.Application.Features.CQRS.Queries.CourseQueries;

namespace OBS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CreateCourseCommandHandler _createCourseCommandHandler;
        private readonly GetCourseByIdQueryHandler _getCourseByIdQueryHandler;
        private readonly GetCourseQueryHandler _getCourseQueryHandler;
        private readonly UpdateCourseCommandHandler _updateCourseCommandHandler;
        private readonly RemoveCourseCommandHandler _removeCourseCommandHandler;
        private readonly GetCoursesWithDepartmentsQueryHandler _getCoursesWithDepartmentsQueryHandler;
        public CoursesController(CreateCourseCommandHandler createCourseCommandHandler, GetCourseByIdQueryHandler getCourseByIdQueryHandler, GetCourseQueryHandler getCourseQueryHandler, UpdateCourseCommandHandler updateCourseCommandHandler, RemoveCourseCommandHandler removeCourseCommandHandler, GetCoursesWithDepartmentsQueryHandler getCoursesWithDepartmentsQueryHandler)
        {
            _createCourseCommandHandler = createCourseCommandHandler;
            _getCourseByIdQueryHandler = getCourseByIdQueryHandler;
            _getCourseQueryHandler = getCourseQueryHandler;
            _updateCourseCommandHandler = updateCourseCommandHandler;
            _removeCourseCommandHandler = removeCourseCommandHandler;
            _getCoursesWithDepartmentsQueryHandler = getCoursesWithDepartmentsQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> CourseList()
        {
            var values = await _getCourseQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var value = await _getCourseByIdQueryHandler.Handle(new GetCourseByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseCommand command)
        {
            await _createCourseCommandHandler.Handle(command);
            return Ok("Ders Eklendi!");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCourse(int id)
        {
            await _removeCourseCommandHandler.Handle(new RemoveCourseCommand(id));
            return Ok("Ders Silindi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourse(UpdateCourseCommand command)
        {
            await _updateCourseCommandHandler.Handle(command);
            return Ok("Ders Güncellendi!");
        }
        [HttpGet("GetCourseWithDepartment")]
        public IActionResult GetCourseWithDepartment()
        {
            var values = _getCoursesWithDepartmentsQueryHandler.Handle();
            return Ok(values);
        }
    }
}
