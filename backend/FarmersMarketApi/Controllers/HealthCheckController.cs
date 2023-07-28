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
            //Check health of SqliteHealthCheck
            var healthCheckResult = await SqliteHealthCheck.CheckHealthAsyncPlz();

            //if healthy return 200
            if (healthCheckResult.Status == HealthStatus.Healthy)
            {
                return Ok();
            }

            //if unhealthy return 503
            return StatusCode(503);
        }

    }
}
