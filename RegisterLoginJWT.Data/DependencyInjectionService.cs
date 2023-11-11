using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegisterLoginJWT.Data.Repositories;
using RegisterLoginJWT.Data.Repositories.Interfaces;
using RegisterLoginJWT.Data.Settings;


namespace RegisterLoginJWT.Data
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
            {
                options.UseSqlServer(JWTConfiguration.BuildConnectionString(configuration));
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
