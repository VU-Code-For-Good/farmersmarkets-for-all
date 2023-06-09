using FarmersMarketApi.Domain.Models;

namespace FarmersMarketApi.Application.InfrastructureInterfaces
{
    public interface IFarmersMarketRepository
    {
        public Task<List<FarmersMarket>> GetFarmersMarkets(string state);
    }
}
