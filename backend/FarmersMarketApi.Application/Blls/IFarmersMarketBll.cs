using FarmersMarketApi.Domain.Models;

namespace FarmersMarketApi.Application.Blls
{
    public interface IFarmersMarketBll
    {
        Task<List<FarmersMarket>> GetFarmersMarketsByStateAsync(string state);
        Task<List<FarmersMarket>> GetFarmersMarketsByZipCodeAsync(string zipCode);
    }
}
