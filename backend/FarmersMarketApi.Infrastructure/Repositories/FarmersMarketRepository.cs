using FarmersMarketApi.Domain.Models;
using FarmersMarketApi.Application.InfrastructureInterfaces;
using FarmersMarketApi.Infrastructure.Contexts;

namespace FarmersMarketApi.Infrastructure.Repositories
{
    public class FarmersMarketRepository : IFarmersMarketRepository
    {
        private readonly IFarmersMarketContext _farmersMarketContext;

        public FarmersMarketRepository(IFarmersMarketContext farmersMarketContext)
        {
            _farmersMarketContext = farmersMarketContext;
        }
        public async Task<List<FarmersMarket>> GetFarmersMarkets(string state)
        {
            var query = "SELECT FROM ";

            using var connection = _farmersMarketContext.CreateConnection();

            //var result = await connection.QueryAsync()

            throw new NotImplementedException();

        }
    }
}
