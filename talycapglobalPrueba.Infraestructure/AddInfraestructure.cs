using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talycapglobalPrueba.Core.Entities;
using talycapglobalPrueba.Core.Interfaces;
using talycapglobalPrueba.Core.Interfaces.Repository;
using talycapglobalPrueba.Core.Interfaces.Services;
using talycapglobalPrueba.Infraestructure.Config;
using talycapglobalPrueba.Infraestructure.Data;
using talycapglobalPrueba.Infraestructure.Model;
using talycapglobalPrueba.Infraestructure.Repository;
using talycapglobalPrueba.Infraestructure.Services;

namespace talycapglobalPrueba.Infraestructure
{
    public static class AddInfraestructure
    {
        public static void AddInfraestructureMethod(this IServiceCollection services, IConfiguration Configuration) {

            #region DbContext
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("TalyConnection"),
                        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
            #endregion DbContext
            #region bussines
            services.AddIdentity<ApplicationUser, IdentityRole>()
       .AddDefaultTokenProviders()
       .AddUserManager<UserManager<ApplicationUser>>()
       .AddSignInManager<SignInManager<ApplicationUser>>()
       .AddEntityFrameworkStores<AppDbContext>();
            services.Configure<IdentityOptions>(
                options =>
                {
                    options.SignIn.RequireConfirmedEmail = true;
                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";


                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;
                });
            #endregion bussines
            #region Data
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepository<Book>, Repository<Book>>();
            services.AddTransient<IRepository<Author>, Repository<Author>>();
            services.AddTransient<IThirdApiRepository, ThirdApiRepository>();

            #endregion Data

            #region Bussines
            services.AddHttpClient();
            services.AddTransient<ISyncService, SyncService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();
            #endregion Bussines

            #region Confg
            services.SetAuthorization();
            services.SetUpAuth(Configuration);
            #endregion Confg
        }
    }
}
