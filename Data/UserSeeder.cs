using Microsoft.AspNetCore.Identity;
using Onyx.Constants;

namespace Onyx.Data
{
    public class UserSeeder
    {
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider, 
            IConfiguration configuration)
        {
            // userManager служи за създаване, редактиране и изтриване на потребителски профили
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var adminEmail = configuration["AdminUser:Email"];
            var adminPassword = configuration["AdminUser:Password"];
            await CreateUserWithRole(userManager, adminEmail, adminPassword, Roles.Admin);
        }

        public static async Task CreateUserWithRole(UserManager<IdentityUser> userManager, string email,
            string password,
            string role)
        {
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser
                {
                    Email = email,
                    EmailConfirmed = true,
                    UserName = email,
                };

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
                else
                {
                    throw new Exception($"Грешка при създаване на потребител с имейл: {user.Email}. " +
                        $"Грешки: {string.Join(",", result.Errors)}");
                }
            }
        }
    }
}
