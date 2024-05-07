using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Authorization.Queries.Models;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Data.Results;
using CleanArchitecture.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Authorization.Queries.Handlers
{
    public class ClaimQueryHandler : ResponseHandler,
                                      IRequestHandler<ManageUserClaimsQuery, Response<ManageUserClaimsResult>>

    {
        #region Field
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<User> _userManager;

        #endregion

        #region CTOR
        public ClaimQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                 IAuthorizationService authorizationService,
                                 UserManager<User> userManager) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            _userManager = userManager;
        }


        #endregion

        #region Method
        public async Task<Response<ManageUserClaimsResult>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                return NotFound<ManageUserClaimsResult>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
            }
            var result = await _authorizationService.GetUserClaims(user);
            return Success(result);
        }
        #endregion

    }
}
