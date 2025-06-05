using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBS.Application.Features.CQRS.Commands.ExamCommands;
using OBS.Application.Features.CQRS.Handlers.ExamHandlers;
using OBS.Application.Features.CQRS.Queries.ExamQueries;

namespace OBS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly CreateExamCommandHandler _createExamCommandHandler;
        private readonly GetExamByIdQueryHandler _getExamByIdQueryHandler;
        private readonly GetExamQueryHandler _getExamQueryHandler;
        private readonly UpdateExamCommandHandler _updateExamCommandHandler;
        private readonly RemoveExamCommandHandler _removeExamCommandHandler;
        private readonly GetExamsWithCoursesAndTeachersQueryHandler _getExamsWithCoursesAndTeachersQueryHandler;
        public ExamsController(CreateExamCommandHandler createExamCommandHandler, GetExamByIdQueryHandler getExamByIdQueryHandler, GetExamQueryHandler getExamQueryHandler, UpdateExamCommandHandler updateExamCommandHandler, RemoveExamCommandHandler removeExamCommandHandler, GetExamsWithCoursesAndTeachersQueryHandler getExamsWithCoursesAndTeachersQueryHandler)
        {
            _createExamCommandHandler = createExamCommandHandler;
            _getExamByIdQueryHandler = getExamByIdQueryHandler;
            _getExamQueryHandler = getExamQueryHandler;
            _updateExamCommandHandler = updateExamCommandHandler;
            _removeExamCommandHandler = removeExamCommandHandler;
            _getExamsWithCoursesAndTeachersQueryHandler = getExamsWithCoursesAndTeachersQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> ExamList()
        {
            var values = await _getExamQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExam(int id)
        {
            var value = await _getExamByIdQueryHandler.Handle(new GetExamByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateExam(CreateExamCommand command)
        {
            await _createExamCommandHandler.Handle(command);
            return Ok("Sınav Eklendi!");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveExam(int id)
        {
            await _removeExamCommandHandler.Handle(new RemoveExamCommand(id));
            return Ok("Sınav Silindi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateExam(UpdateExamCommand command)
        {
            await _updateExamCommandHandler.Handle(command);
            return Ok("Sınav Güncellendi!");
        }
        [HttpGet("GetExamWithCourseAndTeacher")]
        public IActionResult GetExamWithCourseAndTeacher()
        {
            var values = _getExamsWithCoursesAndTeachersQueryHandler.Handle();
            return Ok(values);
        }
    }
}
