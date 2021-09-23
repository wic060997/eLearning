using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.HealthChecks
{
    public static class BackendHealthExtensions
    {
        public static IHealthChecksBuilder AddBackendApiHealthCheck(this IHealthChecksBuilder builder, string url, HealthStatus failureStatus = HealthStatus.Degraded, IEnumerable<string> tags = default)
        {
            return builder.Add(new HealthCheckRegistration(
                "BackendApi",
                sp => new BackendApiHealthCheck(url),
                failureStatus,
                tags));
        }
    }
}
