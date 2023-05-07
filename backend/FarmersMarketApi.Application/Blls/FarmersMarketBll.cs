
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
    public async Task<List<FarmersMarket>> GetFarmersMarketsByStateAsync(string state)
    {
       return await _farmersMarketRepository.GetFarmersMarkets(state);
    }
}
