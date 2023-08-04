using System.Data;

namespace FarmersMarketApi.Infrastructure.Contexts
{
    public interface IFarmersMarketContext
    {
        IDbConnection CreateConnection();

        string GetConnectionString();
    }
}
