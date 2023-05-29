using FarmersMarketApi.Domain.Models;
using FarmersMarketApi.Application.InfrastructureInterfaces;
using FarmersMarketApi.Infrastructure.Contexts;
using Dapper;

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
            
            var query = "SELECT * FROM FarmersMarket fm INNER JOIN ContactInfo ci ON fm.contact = ci.id WHERE ci.address LIKE '%' || @State || ',%'";
            using var connection = _farmersMarketContext.CreateConnection();
            var result = await connection.QueryAsync<FarmersMarket>(query, new { State = state });
            return result.ToList();
        }
    }
}
