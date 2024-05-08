using CleanArchitecture.API.Base;
using CleanArchitecture.Core.Features.Emails.Commands.Models;
using CleanArchitecture.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    public class EmailsController : AppControllerBase
    {
        public EmailsController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize(Policy = "CreateStudent")]
        [HttpPost(LocalRouter.EmailRouting.Send)]
        public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
    }
}
