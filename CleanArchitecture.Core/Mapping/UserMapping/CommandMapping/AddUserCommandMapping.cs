using CleanArchitecture.Core.Features.Users.Commands.Models;
using CleanArchitecture.Data.Entities.Identity;

namespace CleanArchitecture.Core.Mapping.UserMapping
{
    public partial class UserProfile
    {
        public void AddUserCommandMapping()
        {

            CreateMap<AddUserCommand, User>();

        }
    }
}
