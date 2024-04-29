using AutoMapper;

namespace CleanArchitecture.Core.Mapping.UserMapping
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            AddUserCommandMapping();
            GetUserPaginationMapping();
            GetUserByIdMapping();
        }
    }
}
