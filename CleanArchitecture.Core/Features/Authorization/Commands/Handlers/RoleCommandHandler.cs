using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Authorization.Commands.Models;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Authorization.Commands.Handlers
{
    public class RoleCommandHandler : ResponseHandler,
        IRequestHandler<AddRoleCommand, Response<string>>,
        IRequestHandler<EditRoleCommand, Response<string>>

    {

        #region Field
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;

        #endregion

        #region CTOR
        public RoleCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                  IAuthorizationService authorizationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;

        }


        #endregion

        #region Methods
        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {

            var result = await _authorizationService.AddRoleAsync(request.RoleName);
            if (result == "Succeeded")
            {
                return Success(result);
            }
            return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
        }

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.EditRoleAsync(request);
            if (result == "Succeeded")
            {
                return Success(result);
            }
            return BadRequest<string>(result);
        }

        #endregion
    }
}
