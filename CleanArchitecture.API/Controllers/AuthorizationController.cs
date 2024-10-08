﻿using CleanArchitecture.API.Base;
using CleanArchitecture.Core.Features.Authorization.Commands.Models;
using CleanArchitecture.Core.Features.Authorization.Queries.Models;
using CleanArchitecture.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    // [Authorize(Roles = "Admin")]
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

        [HttpPost(LocalRouter.Authorization.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var response = await _mediator.Send(new DeleteRoleCommand(Id));
            return NewResult(response);
        }

        [HttpGet(LocalRouter.Authorization.List)]
        public async Task<IActionResult> GetRolesList()
        {
            var response = await _mediator.Send(new GetRolesListQuery());
            return Ok(response);
        }

        [HttpGet(LocalRouter.Authorization.GetByID)]
        public async Task<IActionResult> GetRoleById([FromRoute] int Id)
        {
            var response = await _mediator.Send(new GetRoleByIdQuery(Id));
            return NewResult(response);
        }

        [HttpGet(LocalRouter.Authorization.ManageUserRoles)]
        public async Task<IActionResult> ManageUserRoles([FromRoute] int userId)
        {
            var response = await _mediator.Send(new ManageUserRolesQuery() { UserId = userId });
            return NewResult(response);
        }

        [HttpPut(LocalRouter.Authorization.UpdateUserRoles)]
        public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesCommand request)
        {
            var response = await _mediator.Send(request);
            return NewResult(response);
        }

        #region claims
        [HttpGet(LocalRouter.Authorization.ManageUserCalims)]
        public async Task<IActionResult> ManageUserClaims([FromRoute] int userId)
        {
            var response = await _mediator.Send(new ManageUserClaimsQuery() { UserId = userId });
            return NewResult(response);
        }

        [HttpPut(LocalRouter.Authorization.UpdateUserClaims)]
        public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimsCommand request)
        {
            var response = await _mediator.Send(request);
            return NewResult(response);
        }
        #endregion

    }
}
