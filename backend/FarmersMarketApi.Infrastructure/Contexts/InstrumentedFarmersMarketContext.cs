using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FarmersMarketApi.Infrastructure.Contexts
{
    public class InstrumentedFarmersMarketContext : IFarmersMarketContext
    {
        private readonly IFarmersMarketContext _farmersMarketContext;
        private readonly ILogger<IFarmersMarketContext> _farmersLogger;

        public InstrumentedFarmersMarketContext(IFarmersMarketContext farmersMarketContext, ILogger<IFarmersMarketContext> farmersLogger)
        {
            _farmersMarketContext = farmersMarketContext;
            _farmersLogger = farmersLogger;
        }

        public IDbConnection CreateConnection()
        {
            _farmersLogger.Log(LogLevel.Information, $"CreateConnection: {_farmersMarketContext.GetConnectionString()}");
            return _farmersMarketContext.CreateConnection();
        }

        public string GetConnectionString()
        {
            return _farmersMarketContext.GetConnectionString();
        }
    }
}
