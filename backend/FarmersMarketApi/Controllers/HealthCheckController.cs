using FarmersMarketApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FarmersMarketApi.Controllers
{
    public class HealthCheckController : ControllerBase
    {
        public SqliteHealthCheck SqliteHealthCheck { get; }

        public HealthCheckController(SqliteHealthCheck sqliteHealthCheck)
        {
            SqliteHealthCheck = sqliteHealthCheck;
        }

        [HttpGet]
        [Route("/health")]
        public async Task<IActionResult> Get()
        {
            var healthCheckResult = await SqliteHealthCheck.CheckHealthAsync();

            if (healthCheckResult.Status == HealthStatus.Healthy)
            {
                return Ok($"Service is healthy.");

            }

            return StatusCode(503, "Service is unhealthy.");
        }

    }
}