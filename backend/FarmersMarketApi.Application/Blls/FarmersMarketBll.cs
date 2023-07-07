
using FarmersMarketApi.Application.InfrastructureInterfaces;
using FarmersMarketApi.Domain.Models;
using Microsoft.Extensions.Logging;

namespace FarmersMarketApi.Application.Blls;
public class FarmersMarketBll : IFarmersMarketBll
{
    private readonly IFarmersMarketRepository _farmersMarketRepository;
    private readonly ILogger<FarmersMarketBll> _logger;

    public FarmersMarketBll(IFarmersMarketRepository farmersMarketRepository, ILogger<FarmersMarketBll> logger)
    {
        _farmersMarketRepository = farmersMarketRepository;
        _logger = logger;
    }
    public async Task<List<FarmersMarket>> GetFarmersMarketsByStateAsync(string searchTerm)
    {
        _logger.Log(LogLevel.Information, "GetFarmersMarketsByState");
       return await _farmersMarketRepository.GetFarmersMarketsByState(searchTerm);
    }

    public async Task<List<FarmersMarket>> GetFarmersMarketsByZipCodeAsync(string zipCode)
    {
        _logger.Log(LogLevel.Information, "GetFarmersMarketsByZipCodeAsync");
        return await _farmersMarketRepository.GetFarmersMarketsByZipCode(zipCode);
    }
}
