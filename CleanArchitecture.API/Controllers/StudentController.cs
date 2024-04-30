using CleanArchitecture.API.Base;
using CleanArchitecture.Core.Features.Students.Commands.Models;
using CleanArchitecture.Core.Features.Students.Queries.Models;
using CleanArchitecture.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{

    [ApiController]
    [Authorize]
    public class StudentController : AppControllerBase
    {
        public StudentController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet(LocalRouter.StudentRouting.PaginatedList)]
        public async Task<IActionResult> GetStudentPaginatedList([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(LocalRouter.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }
        [HttpGet(LocalRouter.StudentRouting.GetByID)]
        public async Task<IActionResult> GetStudentById([FromRoute] int Id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(Id));
            return NewResult(response);
        }

        [HttpPost(LocalRouter.StudentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(LocalRouter.StudentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(LocalRouter.StudentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var response = await _mediator.Send(new DeleteStudentCommand(Id));
            return NewResult(response);
        }
    }
}
