using FarmersMarketApi.Application.InfrastructureInterfaces;
using FarmersMarketApi.Infrastructure.Contexts;
using FarmersMarketApi.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace FarmersMarketApi.Infrastructure
{
    public static class InfrastructureConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IFarmersMarketRepository, FarmersMarketRepository>();
            return services;
        }

        public static IServiceCollection AddExternalInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IFarmersMarketContext>(new FarmersMarketContext(configuration["AppConfiguration:FarmersMarketSqliteFilePath"]));
            services.AddSingleton<SqliteHealthCheck>();
            return services;
        }

    }
}
