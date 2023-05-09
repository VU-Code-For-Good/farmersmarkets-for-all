using System;
using FarmersMarketApi.Domain.Models;
using FarmersMarketApi.Application.InfrastructureInterfaces;

namespace FarmersMarketApi.Infrastructure.Repositories
{
    public class FarmersMarketRepository : IFarmersMarketRepository
    {
        public async Task<List<FarmersMarket>> GetFarmersMarkets(string state)
        {
            throw new NotImplementedException();
        }
    }
}
