using FarmersMarketApi.Domain.Models;

namespace FarmersMarketApi.Application.Blls
{
    public interface IFarmersMarketBll
    {
        Task<List<FarmersMarket>> GetFarmersMarketsAsync(string searchTerm);
    }
}
