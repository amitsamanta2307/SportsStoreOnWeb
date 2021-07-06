using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsStoreOnWeb.ApplicationCore.Interfaces;
using SportsStoreOnWeb.Infrastructure.Data;

namespace SportsStoreOnWeb.Web.Configuration
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

            return services;
        }
    }
}