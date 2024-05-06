using CleanArchitecture.Core.Features.Authorization.Queries.Results;
using CleanArchitecture.Data.Entities.Identity;

namespace CleanArchitecture.Core.Mapping.AuthorizationMapping
{
    public partial class AuthorizationProfile
    {
        public void GetRoleListMapping()
        {
            CreateMap<Role, GetRolesListReponse>();
        }
    }
}
