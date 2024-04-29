using CleanArchitecture.API.Base;
using CleanArchitecture.Core.Features.Users.Commands.Models;
using CleanArchitecture.Core.Features.Users.Queries.Models;
using CleanArchitecture.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : AppControllerBase
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(LocalRouter.UserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet(LocalRouter.UserRouting.PaginatedList)]
        public async Task<IActionResult> GetUserPaginatedList([FromQuery] GetUserPaginationQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(LocalRouter.UserRouting.GetByID)]
        public async Task<IActionResult> GetUserById([FromQuery] int Id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(Id));
            return NewResult(response);
        }
    }
}
