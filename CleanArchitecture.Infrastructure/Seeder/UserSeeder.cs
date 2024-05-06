using CleanArchitecture.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Seeder
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<User> userManager)
        {
            var usersCount = await userManager.Users.CountAsync();
            if (usersCount == 0)
            {
                var defaultUser = new User()
                {
                    UserName = "admin@project.com",
                    Email = "admin@project.com",
                    FullName = "admin",
                    EmailConfirmed = true

                };
                await userManager.CreateAsync(defaultUser, "M123_m");
                await userManager.AddToRoleAsync(defaultUser, "Admin");
            }
        }
    }
}
