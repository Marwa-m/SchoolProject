using CleanArchitecture.Core.Features.Users.Queries.Results;
using CleanArchitecture.Data.Entities.Identity;

namespace CleanArchitecture.Core.Mapping.UserMapping
{
    public partial class UserProfile
    {
        public void GetUserPaginationMapping()
        {
            CreateMap<User, GetUserPaginationResponse>();
        }

    }
}
