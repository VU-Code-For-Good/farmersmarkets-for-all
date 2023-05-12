
using FarmersMarketApi.Application.InfrastructureInterfaces;
using FarmersMarketApi.Domain.Models;

namespace FarmersMarketApi.Application.Blls;
public class FarmersMarketBll : IFarmersMarketBll
{
    private readonly IFarmersMarketRepository _farmersMarketRepository;

    public FarmersMarketBll(IFarmersMarketRepository farmersMarketRepository)
    {
        _farmersMarketRepository = farmersMarketRepository;
    }
    public async Task<List<FarmersMarket>> GetFarmersMarketsAsync(string searchTerm)
    {
       return await _farmersMarketRepository.GetFarmersMarkets(searchTerm);
    }
}
