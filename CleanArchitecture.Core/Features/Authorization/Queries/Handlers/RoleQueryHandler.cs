using AutoMapper;
using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Authorization.Commands.Models;
using CleanArchitecture.Core.Features.Authorization.Queries.Models;
using CleanArchitecture.Core.Features.Authorization.Queries.Results;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Data.DTOs;
using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Authorization.Queries.Handlers
{
    public class RoleQueryHandler : ResponseHandler,
        IRequestHandler<GetRolesListQuery, Response<List<GetRolesListReponse>>>,
        IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResult>>,
        IRequestHandler<ManageUserRolesQuery, Response<ManageUserRolesResult>>




    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public RoleQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                IAuthorizationService authorizationService,
                                IMapper mapper,
                                UserManager<User> userManager) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            _mapper = mapper;
            _userManager = userManager;
        }
        #region Fields

        #endregion

        #region CTOR

        #endregion

        #region Methods
        public async Task<Response<List<GetRolesListReponse>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roleList = await _authorizationService.GetRolesAsync();
            var roleListMapper = _mapper.Map<List<Role>, List<GetRolesListReponse>>(roleList);
            var result = Success(roleListMapper);
            result.Meta = new { Count = roleListMapper.Count() };
            return result;
        }
        public async Task<Response<GetRoleByIdResult>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorizationService.GetRoleByIdAsync(request.Id);
            if (role == null)
                return NotFound<GetRoleByIdResult>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var roleMapper = _mapper.Map<Role, GetRoleByIdResult>(role);
            return (Success(roleMapper));
        }

        public async Task<Response<ManageUserRolesResult>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                return NotFound<ManageUserRolesResult>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
            }
            var result = await _authorizationService.GetUserRoles(user);
            return Success(result);
        }


        #endregion

    }
}
