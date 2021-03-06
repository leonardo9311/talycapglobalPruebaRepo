using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talycapglobalPrueba.Infraestructure.Identity;
using talycapglobalPrueba.Infraestructure.Model;

namespace talycapglobalPrueba.Infraestructure.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static async Task SeedIdentityDataAsync(this IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                await ApplicationDbContextDataSeed.SeedAsync(userManager, roleManager);
            }
        }
    }
}
