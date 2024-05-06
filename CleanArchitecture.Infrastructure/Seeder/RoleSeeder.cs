using CleanArchitecture.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Seeder
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<Role> roleManager)
        {
            var rolesCount = await roleManager.Roles.CountAsync();
            if (rolesCount == 0)
            {
                var defaultRole = new Role()
                {
                    Name = "Admin"

                };
                await roleManager.CreateAsync(defaultRole);
                defaultRole = new Role()
                {
                    Name = "User"

                };
                await roleManager.CreateAsync(defaultRole);
            }
        }

    }
}
