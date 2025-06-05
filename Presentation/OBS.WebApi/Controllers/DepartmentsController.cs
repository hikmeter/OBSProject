using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBS.Application.Features.CQRS.Commands.DepartmentCommands;
using OBS.Application.Features.CQRS.Handlers.DepartmentHandlers;
using OBS.Application.Features.CQRS.Queries.DepartmentQueries;

namespace OBS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly CreateDepartmentCommandHandler _createDepartmentCommandHandler;
        private readonly GetDepartmentByIdQueryHandler _getDepartmentByIdQueryHandler;
        private readonly GetDepartmentQueryHandler _getDepartmentQueryHandler;
        private readonly UpdateDepartmentCommandHandler _updateDepartmentCommandHandler;
        private readonly RemoveDepartmentCommandHandler _removeDepartmentCommandHandler;
        private readonly GetDepartmentsWithFacultiesQueryHandler _getDepartmentsWithFacultiesQueryHandler;
        public DepartmentsController(CreateDepartmentCommandHandler createDepartmentCommandHandler, GetDepartmentByIdQueryHandler getDepartmentByIdQueryHandler, GetDepartmentQueryHandler getDepartmentQueryHandler, UpdateDepartmentCommandHandler updateDepartmentCommandHandler, RemoveDepartmentCommandHandler removeDepartmentCommandHandler, GetDepartmentsWithFacultiesQueryHandler getDepartmentsWithFacultiesQueryHandler)
        {
            _createDepartmentCommandHandler = createDepartmentCommandHandler;
            _getDepartmentByIdQueryHandler = getDepartmentByIdQueryHandler;
            _getDepartmentQueryHandler = getDepartmentQueryHandler;
            _updateDepartmentCommandHandler = updateDepartmentCommandHandler;
            _removeDepartmentCommandHandler = removeDepartmentCommandHandler;
            _getDepartmentsWithFacultiesQueryHandler = getDepartmentsWithFacultiesQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> DepartmentList()
        {
            var values = await _getDepartmentQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var value = await _getDepartmentByIdQueryHandler.Handle(new GetDepartmentByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentCommand command)
        {
            await _createDepartmentCommandHandler.Handle(command);
            return Ok("Bölüm Eklendi!");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveDepartment(int id)
        {
            await _removeDepartmentCommandHandler.Handle(new RemoveDepartmentCommand(id));
            return Ok("Bölüm Silindi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentCommand command)
        {
            await _updateDepartmentCommandHandler.Handle(command);
            return Ok("Bölüm Güncellendi!");
        }
        [HttpGet("GetDepartmentsWithFaculties")]
        public IActionResult GetDepartmentsWithFaculties()
        {
            var values = _getDepartmentsWithFacultiesQueryHandler.Handle();
            return Ok(values);
        }
    }
}
