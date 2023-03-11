using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Dobany.EntityFrameworkCore;

namespace Dobany.HealthChecks
{
    public class DobanyDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public DobanyDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("DobanyDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("DobanyDbContext could not connect to database"));
        }
    }
}
