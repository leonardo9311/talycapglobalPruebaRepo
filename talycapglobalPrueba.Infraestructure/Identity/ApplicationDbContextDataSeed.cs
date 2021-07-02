using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talycapglobalPrueba.Infraestructure.Model;

namespace talycapglobalPrueba.Infraestructure.Identity
{
    public static class ApplicationDbContextDataSeed
    {
        public static object ApplicationIdentityConstants { get; private set; }

        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            
             await roleManager.CreateAsync(new IdentityRole(Core.Constants.ApplicationIdentityConstants.Roles.Administrator));
            await roleManager.CreateAsync(new IdentityRole(Core.Constants.ApplicationIdentityConstants.Roles.Member));

         
            string adminUserName = "leonardo@test.co";
            var adminUser = new ApplicationUser
            {
                UserName = adminUserName,
                Email = adminUserName,
                IsEnabled = true,
                EmailConfirmed = true,
                FirstName = "leonardo",
                LastName = "Administrator"
            };

            // Add new user and their role
            await userManager.CreateAsync(adminUser, Core.Constants.ApplicationIdentityConstants.DefaultPassword);
            adminUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminUser, Core.Constants.ApplicationIdentityConstants.Roles.Administrator);
        }
    }
}
