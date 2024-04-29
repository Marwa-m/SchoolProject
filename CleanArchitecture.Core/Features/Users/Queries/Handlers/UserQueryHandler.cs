using AutoMapper;
using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Users.Queries.Models;
using CleanArchitecture.Core.Features.Users.Queries.Results;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Core.Wrapper;
using CleanArchitecture.Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Users.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
                                 IRequestHandler<GetUserPaginationQuery, PaginatedResult<GetUserPaginationResponse>>,
                                 IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #endregion

        #region CTOR
        public UserQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
            IMapper mapper,
            UserManager<User> userManager) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _userManager = userManager;
        }


        #endregion

        #region Function
        public async Task<PaginatedResult<GetUserPaginationResponse>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users;

            var paginatedList = _mapper.ProjectTo<GetUserPaginationResponse>(users).ToPaginatedListAsync((int)request.PageNumber, (int)request.PageSize).Result;
            paginatedList.Meta = new { Count = paginatedList.Data.Count() };
            return paginatedList;
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user == null)
                return NotFound<GetUserByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var userMapper = _mapper.Map<GetUserByIdResponse>(user);
            return (Success(userMapper));

        }


        #endregion
    }
}
