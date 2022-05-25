using AlphaBugTracker.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AlphaBugTracker.Models
{
    public static class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            List<string> roles = new List<string>()
            {
                "Admin",
                "Project Manager",
                "Developer",
            };


            if (!context.Roles.Any())
            {
                foreach (string role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                IdentityUser adminUser = new IdentityUser
                {
                    Email = "Admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    UserName = "Admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                };

                IdentityUser projectManager = new IdentityUser
                {
                    Email = "ProjectManager@mitt.ca",
                    NormalizedEmail = "PROJECTMANAGER@MITT.CA",
                    UserName = "ProjectManager@mitt.ca",
                    NormalizedUserName = "PROJECTMANAGER@MITT.CA",
                    EmailConfirmed = true,
                };

                IdentityUser developer1 = new IdentityUser
                {
                    Email = "Developer1@mitt.ca",
                    NormalizedEmail = "DEVELOPER1@MITT.CA",
                    UserName = "Developer1@mitt.ca",
                    NormalizedUserName = "DEVELOPER1@MITT.CA",
                    EmailConfirmed = true,
                };

                IdentityUser developer2 = new IdentityUser
                {
                    Email = "Developer2@mitt.ca",
                    NormalizedEmail = "DEVELOPER2@MITT.CA",
                    UserName = "Developer2@mitt.ca",
                    NormalizedUserName = "DEVELOPER2@MITT.CA",
                    EmailConfirmed = true,
                };

                var password = new PasswordHasher<IdentityUser>();

                var hashed = password.HashPassword(adminUser, "P@ssword1");
                adminUser.PasswordHash = hashed;

                var hashed2 = password.HashPassword(projectManager, "P@ssword1");
                projectManager.PasswordHash = hashed2;

                var hashed3 = password.HashPassword(developer1, "P@ssword1");
                developer1.PasswordHash = hashed3;

                var hashed4 = password.HashPassword(developer2, "P@ssword1");
                developer2.PasswordHash = hashed4;

                await userManager.CreateAsync(adminUser);
                await userManager.AddToRoleAsync(adminUser, "Admin");

                await userManager.CreateAsync(projectManager);
                await userManager.AddToRoleAsync(projectManager, "Project Manager");

                await userManager.CreateAsync(developer1);
                await userManager.AddToRoleAsync(developer1, "Developer");

                await userManager.CreateAsync(developer2);
                await userManager.AddToRoleAsync(developer2, "Developer");

            }

            await context.SaveChangesAsync();
        }
    }


}