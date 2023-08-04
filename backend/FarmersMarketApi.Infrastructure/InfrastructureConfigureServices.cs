using FarmersMarketApi.Application.InfrastructureInterfaces;
using FarmersMarketApi.Infrastructure.Contexts;
using FarmersMarketApi.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


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
            
            services.AddSingleton<IFarmersMarketContext>(t =>
            {
                var filePath = configuration["AppConfiguration:FarmersMarketSqliteFilePath"];
                IFarmersMarketContext farmersMarketContext = new FarmersMarketContext(filePath);
                ILogger<IFarmersMarketContext> logger = t.GetService<ILogger<IFarmersMarketContext>>();
                return new InstrumentedFarmersMarketContext(farmersMarketContext, logger);
            });
            

            services.AddSingleton<SqliteHealthCheck>();
            return services;
        }
        
    }
}
