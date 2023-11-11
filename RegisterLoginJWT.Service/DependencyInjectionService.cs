using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegisterLoginJWT.Data.Repositories;
using RegisterLoginJWT.Data.Repositories.Interfaces;
using RegisterLoginJWT.Data.Settings;
using RegisterLoginJWT.Service.Interfaces;

namespace RegisterLoginJWT.Service
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IRegisterServices, RegisterServices>();
            services.AddScoped<ILoginServices, LoginServices>();


            return services;
        }
    }
}
