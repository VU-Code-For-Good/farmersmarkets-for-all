using System.Data;
using Microsoft.Data.Sqlite;


namespace FarmersMarketApi.Infrastructure.Contexts
{
    public class FarmersMarketContext : IFarmersMarketContext
    {
        private readonly string? _filePath;

        public FarmersMarketContext(string filePath)
        {
            _filePath = filePath;
        }
        public IDbConnection CreateConnection() => new SqliteConnection(GetConnectionString());
        public string GetConnectionString()
        {
            return $"Data Source={_filePath}";
        }
    }
}
