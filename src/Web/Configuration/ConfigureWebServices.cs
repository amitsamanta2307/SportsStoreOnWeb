using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsStoreOnWeb.Web.Services;

namespace SportsStoreOnWeb.Web.Configuration
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductViewModelService, ProductViewModelService>();

            return services;
        }
    }
}