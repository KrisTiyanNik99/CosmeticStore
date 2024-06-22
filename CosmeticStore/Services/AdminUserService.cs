using BeautyCareStore.Models;
using Microsoft.AspNetCore.Identity;

namespace BeautyCareStore.Services
{
    public class AdminUserService : IAdminUserService
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminUserService(UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAdminUserAsync()
        {
            var adminUserName = "admin";
            var adminEmail = "admin@example.com";
            var adminPassword = "12344321Aa+";
            var adminRoleName = "Admin";
            var adminFirstName = " ";
            var adminLastName = " ";

            // Create Admin role if it doesn't exist
            var roleExists = await _roleManager.RoleExistsAsync(adminRoleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole(adminRoleName));
            }

            // Create Admin user if it doesn't exist
            var adminUser = await _userManager.FindByNameAsync(adminUserName);
            if (adminUser == null)
            {
                adminUser = new CustomUser { UserName = adminUserName, Email = adminEmail };
                adminUser.FirstName = adminFirstName;
                adminUser.LastName = adminLastName;

                var result = await _userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, adminRoleName);
                }
                else
                {
                    var errors = string.Join(", ", result.Errors);
                    throw new Exception($"Failed to create admin user. Errors: {errors}");
                }
            }
        }
    }
}