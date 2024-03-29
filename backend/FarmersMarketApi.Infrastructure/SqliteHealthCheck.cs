using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FarmersMarketApi.Infrastructure
{
    public class SqliteHealthCheck
    {
        private readonly string _connectionString = "FarmersMarket.db";

        public async Task<HealthCheckResult> CheckHealthAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={_connectionString}"))
                {
                    await connection.OpenAsync(cancellationToken);

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT 1";
                        await command.ExecuteNonQueryAsync(cancellationToken);
                    }

                
                    return HealthCheckResult.Healthy("Healthy Database.");
                }
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy("Database connection failure.", ex);
            }
        }
    }
}
