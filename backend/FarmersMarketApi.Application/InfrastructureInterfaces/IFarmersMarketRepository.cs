using FarmersMarketApi.Domain.Models;

namespace FarmersMarketApi.Application.InfrastructureInterfaces
{
    public interface IFarmersMarketRepository
    {
        public Task<List<FarmersMarket>> GetFarmersMarketsByState(string state);
        public Task<List<FarmersMarket>> GetFarmersMarketsByZipCode(string zipCode);
    }
}
