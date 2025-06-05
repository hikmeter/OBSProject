using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBS.Application.Features.CQRS.Commands.StudentExamCommands;
using OBS.Application.Features.CQRS.Handlers.StudentExamHandlers;
using OBS.Application.Features.CQRS.Queries.StudentExamQueries;

namespace OBS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamsController : ControllerBase
    {
        private readonly CreateStudentExamCommandHandler _createStudentExamCommandHandler;
        private readonly GetStudentExamByIdQueryHandler _getStudentExamByIdQueryHandler;
        private readonly GetStudentExamQueryHandler _getStudentExamQueryHandler;
        private readonly UpdateStudentExamCommandHandler _updateStudentExamCommandHandler;
        private readonly RemoveStudentExamCommandHandler _removeStudentExamCommandHandler;
        public StudentExamsController(CreateStudentExamCommandHandler createStudentExamCommandHandler, GetStudentExamByIdQueryHandler getStudentExamByIdQueryHandler, GetStudentExamQueryHandler getStudentExamQueryHandler, UpdateStudentExamCommandHandler updateStudentExamCommandHandler, RemoveStudentExamCommandHandler removeStudentExamCommandHandler)
        {
            _createStudentExamCommandHandler = createStudentExamCommandHandler;
            _getStudentExamByIdQueryHandler = getStudentExamByIdQueryHandler;
            _getStudentExamQueryHandler = getStudentExamQueryHandler;
            _updateStudentExamCommandHandler = updateStudentExamCommandHandler;
            _removeStudentExamCommandHandler = removeStudentExamCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> StudentExamList()
        {
            var values = await _getStudentExamQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentExam(int id)
        {
            var value = await _getStudentExamByIdQueryHandler.Handle(new GetStudentExamByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudentExam(CreateStudentExamCommand command)
        {
            await _createStudentExamCommandHandler.Handle(command);
            return Ok("Öğrenci Notu Eklendi!");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveStudentExam(int id)
        {
            await _removeStudentExamCommandHandler.Handle(new RemoveStudentExamCommand(id));
            return Ok("Öğrenci Notu Silindi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudentExam(UpdateStudentExamCommand command)
        {
            await _updateStudentExamCommandHandler.Handle(command);
            return Ok("Öğrenci Notu Güncellendi!");
        }
    }
}
