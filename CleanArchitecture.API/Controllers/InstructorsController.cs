using CleanArchitecture.API.Base;
using CleanArchitecture.Core.Features.Instructors.Commands.Models;
using CleanArchitecture.Core.Features.Instructors.Queries.Models;
using CleanArchitecture.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : AppControllerBase
    {
        public InstructorsController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet(LocalRouter.InstructorRouting.GetSalarySummation)]
        public async Task<IActionResult> GetSalarySummation()
        {
            var response = await _mediator.Send(new GetSummationSalaryOfInstructorQuery());
            return NewResult(response);
        }

        [HttpPost(LocalRouter.InstructorRouting.AddInstructor)]
        public async Task<IActionResult> AddInstructor([FromForm] AddInstructorCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
    }
}
