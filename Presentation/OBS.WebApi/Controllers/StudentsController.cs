using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBS.Application.Features.CQRS.Commands.StudentCommands;
using OBS.Application.Features.CQRS.Handlers.StudentHandlers;
using OBS.Application.Features.CQRS.Queries.StudentQueries;

namespace OBS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        private readonly GetStudentByIdQueryHandler _getStudentByIdQueryHandler;
        private readonly GetStudentQueryHandler _getStudentQueryHandler;
        private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;
        private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        private readonly GetStudentsWithDepartmentsQueryHandler _getStudentsWithDepartmentsQueryHandler;
        public StudentsController(CreateStudentCommandHandler createStudentCommandHandler, GetStudentByIdQueryHandler getStudentByIdQueryHandler, GetStudentQueryHandler getStudentQueryHandler, UpdateStudentCommandHandler updateStudentCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler, GetStudentsWithDepartmentsQueryHandler getStudentsWithDepartmentsQueryHandler)
        {
            _createStudentCommandHandler = createStudentCommandHandler;
            _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
            _getStudentQueryHandler = getStudentQueryHandler;
            _updateStudentCommandHandler = updateStudentCommandHandler;
            _removeStudentCommandHandler = removeStudentCommandHandler;
            _getStudentsWithDepartmentsQueryHandler = getStudentsWithDepartmentsQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> StudentList()
        {
            var values = await _getStudentQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var value = await _getStudentByIdQueryHandler.Handle(new GetStudentByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentCommand command)
        {
            await _createStudentCommandHandler.Handle(command);
            return Ok("Öğrenci Eklendi!");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveStudent(int id)
        {
            await _removeStudentCommandHandler.Handle(new RemoveStudentCommand(id));
            return Ok("Öğrenci Silindi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(UpdateStudentCommand command)
        {
            await _updateStudentCommandHandler.Handle(command);
            return Ok("Öğrenci Güncellendi!");
        }
        [HttpGet("GetStudentWithDepartment")]
        public IActionResult GetStudentWithDepartment()
        {
            var values = _getStudentsWithDepartmentsQueryHandler.Handle();
            return Ok(values);
        }
    }
}
