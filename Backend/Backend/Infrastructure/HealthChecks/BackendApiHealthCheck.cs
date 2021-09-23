using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Infrastructure.HealthChecks
{
    public class BackendApiHealthCheck : IHealthCheck
    {
        private string url { get; set; }

        public BackendApiHealthCheck(string url)
        {
            this.url = url;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    var result = await client.DownloadStringTaskAsync(url).ConfigureAwait(false);
                    if (string.IsNullOrWhiteSpace(result))
                    {
                        return new HealthCheckResult(context.Registration.FailureStatus, "Result is empty");
                    }
                    else
                    {
                        Regex reg = new Regex(@"^""\d{1,3}[.]\d{1,3}[.]\d{1,3}[.]\d{1,3}""$");
                        if (!reg.IsMatch(result))
                            return new HealthCheckResult(context.Registration.FailureStatus, "Invalid response");
                    }
                    return HealthCheckResult.Healthy();
                }
            }
            catch (Exception ex)
            {
                return new HealthCheckResult(context.Registration.FailureStatus, exception: ex);
            }
        }
    }
}
