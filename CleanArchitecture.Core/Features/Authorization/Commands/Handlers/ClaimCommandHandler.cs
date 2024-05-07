using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Authorization.Commands.Models;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Authorization.Commands.Handlers
{
    public class ClaimCommandHandler : ResponseHandler,
        //IRequestHandler<AddClaimCommand, Response<string>>,
        //IRequestHandler<EditClaimCommand, Response<string>>,
        //IRequestHandler<DeleteClaimCommand, Response<string>>,
        IRequestHandler<UpdateUserClaimsCommand, Response<string>>

    {

        #region Field
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;

        #endregion

        #region CTOR
        public ClaimCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                  IAuthorizationService authorizationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;

        }


        #endregion

        #region Methods
        //public async Task<Response<string>> Handle(AddClaimCommand request, CancellationToken cancellationToken)
        //{

        //    var result = await _authorizationService.AddClaimAsync(request.ClaimName);
        //    if (result == "Succeeded")
        //    {
        //        return Success(result);
        //    }
        //    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
        //}

        //public async Task<Response<string>> Handle(EditClaimCommand request, CancellationToken cancellationToken)
        //{
        //    var result = await _authorizationService.EditClaimAsync(request);
        //    if (result == "Succeeded")
        //    {
        //        return Success(result);
        //    }
        //    return BadRequest<string>(result);
        //}

        //public async Task<Response<string>> Handle(DeleteClaimCommand request, CancellationToken cancellationToken)
        //{
        //    var result = await _authorizationService.DeleteClaimAsync(request.Id);
        //    if (result == "Succeeded")
        //    {
        //        return Success(result);
        //    }
        //    return BadRequest<string>(result);
        //}
        public async Task<Response<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserClaims(request);
            switch (result)
            {
                case "UserNotFound": return NotFound<string>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
                case "FailedToRemoveOldClaims": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToRemoveOldClaims]);
                case "FailedToAddNewClaims": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToAddNewClaims]);
                case "FailedToUpdate": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToUpdateClaims]);
            }
            return Success<string>(_stringLocalizer[SharedResourcesKeys.Success]);
        }
        #endregion
    }
}
