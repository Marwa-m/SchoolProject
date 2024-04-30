using CleanArchitecture.API.Base;
using CleanArchitecture.Core.Features.Authentication.Commands.Models;
using CleanArchitecture.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {
        public AuthenticationController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost(LocalRouter.Authentication.SignIn)]
        public async Task<IActionResult> Create([FromForm] SignInCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
    }
}
