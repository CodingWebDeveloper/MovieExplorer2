using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MovieExplorer.Common;
using MovieExplorer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Data.Seeding
{
    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (dbContext.Users.Any())
            {
                return;
            }

            ApplicationUser user1 = new ApplicationUser
            {
                UserName = "Go4ko",
                PasswordHash = "Miro%1234567890",
                Email = "georgikostadinov14@abv.bg",
            };

            ApplicationUser user2 = new ApplicationUser
            {
                UserName = "Miro123",
                PasswordHash = "Gochko%1234567890",
                Email = "miroslavuzunov14@abv.bg",
            };

            ApplicationUser user3 = new ApplicationUser
            {
               UserName = "Admin",
               PasswordHash = "Admin%tester1234",
               Email = "adminTest@abv.bg",
            };

            ApplicationUser normalUser = new ApplicationUser
            {
                UserName = "User-test",
                PasswordHash = "User%1234560",
                Email = "normal@abv.bg",
            };

            await userManager.CreateAsync(user1, user1.PasswordHash);
            await userManager.CreateAsync(user2, user2.PasswordHash);
            await userManager.CreateAsync(user3, user3.PasswordHash);
            await userManager.CreateAsync(normalUser, normalUser.PasswordHash);

            await userManager.AddToRoleAsync(user1, GlobalConstants.AdministratorRoleName);
            await userManager.AddToRoleAsync(user2, GlobalConstants.AdministratorRoleName);
            await userManager.AddToRoleAsync(user3, GlobalConstants.AdministratorRoleName);
        }
    }
}
