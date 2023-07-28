using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FarmersMarketApi
{
    public class SqliteHealthCheck
    {
        private readonly string _connectionString = "FarmersMarket.db";
        
        public async Task<HealthCheckResult> CheckHealthAsyncPlz(CancellationToken cancellationToken = default)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={_connectionString}"))
                {
                    connection.OpenAsync(cancellationToken);
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT 1";
                        command.ExecuteNonQueryAsync(cancellationToken);
                    }

                    return HealthCheckResult.Healthy();
                }
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy();
            }
        }
    }
}
