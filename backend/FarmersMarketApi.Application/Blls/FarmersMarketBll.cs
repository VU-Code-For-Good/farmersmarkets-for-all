using FarmersMarketApi.Domain.Models;

namespace FarmersMarketApi.Application.Blls;
public class FarmersMarketBll : IFarmersMarketBll
{
    public Task<List<FarmersMarket>> GetFarmersMarketsByStateAsync(string state)
    {
        throw new NotImplementedException();
    }
}
