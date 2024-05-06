using AutoMapper;

namespace CleanArchitecture.Core.Mapping.AuthorizationMapping
{
    public partial class AuthorizationProfile : Profile
    {
        public AuthorizationProfile()
        {
            GetRoleListMapping();
            GetRoleByIdMapping();
        }
    }
}
