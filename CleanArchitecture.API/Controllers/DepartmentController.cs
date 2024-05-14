using CleanArchitecture.API.Base;
using CleanArchitecture.Core.Features.Departments.Queries.Models;
using CleanArchitecture.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        public DepartmentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet(LocalRouter.DepartmentRouting.GetByID)]
        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentByIdQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }

        [HttpGet(LocalRouter.DepartmentRouting.GetDepartmentStudentCount)]
        public async Task<IActionResult> GetDepartmentStudentCount()
        {
            var response = await _mediator.Send(new GetDepartmentStudentListCountQuery());
            return NewResult(response);
        }
        [HttpGet(LocalRouter.DepartmentRouting.GetDepartmentStudentCountById)]
        public async Task<IActionResult> GetDepartmentStudentCountById([FromRoute] int Id)
        {
            var response = await _mediator.Send(new GetDepartmentStudentCountByIdQuery() { DID = Id });
            return NewResult(response);
        }
    }
}
