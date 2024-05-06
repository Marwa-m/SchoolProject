using CleanArchitecture.API.Base;
using CleanArchitecture.Core.Features.Authorization.Commands.Models;
using CleanArchitecture.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AuthorizationController : AppControllerBase
    {
        public AuthorizationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(LocalRouter.Authorization.Create)]
        public async Task<IActionResult> Create([FromForm] AddRoleCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost(LocalRouter.Authorization.Edit)]
        public async Task<IActionResult> Edit([FromForm] EditRoleCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
    }
}
