using FarmersMarketApi.Domain.Models;
using FarmersMarketApi.Application.InfrastructureInterfaces;
using FarmersMarketApi.Infrastructure.Contexts;
using Dapper;
using Microsoft.Extensions.Logging;

namespace FarmersMarketApi.Infrastructure.Repositories
{
    public class FarmersMarketRepository : IFarmersMarketRepository
    {
        private readonly IFarmersMarketContext _farmersMarketContext;
        private readonly ILogger<FarmersMarketRepository> _logger;

        public FarmersMarketRepository(IFarmersMarketContext farmersMarketContext, ILogger<FarmersMarketRepository> logger)
        {
            _farmersMarketContext = farmersMarketContext;
            _logger = logger;
        }

        public async Task<List<FarmersMarket>> GetFarmersMarketsByState(string state)
        {
            _logger.LogInformation($"Finding farmers markets in {state}");

            var query = "SELECT fm.Id, fm.Name, ci.address " +
                        "FROM FarmersMarket fm " +
                        "INNER JOIN ContactInfo ci ON fm.contact = ci.id " +
                        "WHERE ci.address LIKE '%' || @State || ',%'";

            using var connection = _farmersMarketContext.CreateConnection();
            var result = await connection.QueryAsync<FarmersMarket, string, FarmersMarket>(query,
                (farmersMarket, address) =>
                {
                    farmersMarket.StreetAddress = GetAddressComponent(address, 0);
                    farmersMarket.City = GetAddressComponent(address, 1);
                    farmersMarket.State = GetAddressComponent(address, 2);
                    farmersMarket.ZipCode = GetAddressComponent(address, 3);
                    return farmersMarket;
                },
                new { State = state },
                splitOn: "address");

            _logger.LogInformation($"Found {result.Count()} farmers markets in {state}");
            return result.AsList();
        }

        public async Task<List<FarmersMarket>> GetFarmersMarketsByZipCode(string zipCode)
        {
            _logger.LogInformation($"Finding farmers markets in {zipCode}");
            var query = "SELECT fm.Id, fm.Name, ci.address " +
                        "FROM FarmersMarket fm " +
                        "INNER JOIN ContactInfo ci ON fm.contact = ci.id " +
                        "WHERE ci.address LIKE '%' || @ZipCode || '%'";

            using var connection = _farmersMarketContext.CreateConnection();
            var result = await connection.QueryAsync<FarmersMarket, string, FarmersMarket>(query,
                (farmersMarket, address) =>
                {
                    farmersMarket.StreetAddress = GetAddressComponent(address, 0);
                    farmersMarket.City = GetAddressComponent(address, 1);
                    farmersMarket.State = GetAddressComponent(address, 2);
                    farmersMarket.ZipCode = GetAddressComponent(address, 3);
                    return farmersMarket;
                },
                new { ZipCode = zipCode },
                splitOn: "address");

            _logger.LogInformation($"Found {result.Count()} farmers markets in {zipCode}");
            return result.AsList();
        }

        private static string GetAddressComponent(string address, int index)
        {
            var addressComponents = address?.Split(',');
            return addressComponents?.Length > index ? addressComponents[index].Trim() : null;
        }
    }
}