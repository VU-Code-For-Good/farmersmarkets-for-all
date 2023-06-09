
using FarmersMarketApi.Application.Blls;
using Microsoft.Extensions.DependencyInjection;

namespace FarmersMarketApi.Application
{
    public static class ApplicationConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IFarmersMarketBll, FarmersMarketBll>();
            return services;
        }

    }
}
