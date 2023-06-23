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

        public async Task<List<FarmersMarket>> GetFarmersMarketsByState(string state)
        {
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

            return result.AsList();
        }

        public async Task<List<FarmersMarket>> GetFarmersMarketsByZipCode(string zipCode)
        {
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

            return result.AsList();
        }

        private static string GetAddressComponent(string address, int index)
        {
            var addressComponents = address?.Split(',');
            return addressComponents?.Length > index ? addressComponents[index].Trim() : null;
        }
    }
}