
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace talycapglobalPrueba.Infraestructure.Config
{
    public static class AuthorizationConfigSet
    {
        public static void SetAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(
                options =>
                {
                    options.AddPolicy(
                        JwtBearerDefaults.AuthenticationScheme,
                        new AuthorizationPolicyBuilder()
                            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                            .RequireAuthenticatedUser()
                            .Build());
                });
        }
    }
}
