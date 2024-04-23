using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyBucks.Internal.Infrastructure.Identity.Configurations;
using SurveyBucks.Internal.Infrastructure.Identity.Contracts;
using SurveyBucks.Internal.Infrastructure.Identity.DbContexts;
using SurveyBucks.Internal.Infrastructure.Identity.Models;

namespace SurveyBucks.Internal.Infrastructure.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTOptions>(configuration.GetSection("JWTOptions"));

            services.AddDbContext<ApplicationIdentityDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>().AddDefaultTokenProviders();

            //services.AddTransient<IAuthService, AuthService>();

            return services;
        }
    }
}
