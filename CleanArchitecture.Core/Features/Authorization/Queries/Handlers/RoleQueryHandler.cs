using AutoMapper;
using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Authorization.Queries.Models;
using CleanArchitecture.Core.Features.Authorization.Queries.Results;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Authorization.Queries.Handlers
{
    public class RoleQueryHandler : ResponseHandler,
        IRequestHandler<GetRolesListQuery, Response<List<GetRolesListReponse>>>,
        IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResult>>

    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;

        public RoleQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                IAuthorizationService authorizationService,
                                IMapper mapper) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            _mapper = mapper;
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
        #endregion

    }
}
