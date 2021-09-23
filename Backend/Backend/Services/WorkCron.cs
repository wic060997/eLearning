using Microsoft.Extensions.Logging;
using Model.MaterialModel.IService;
using Model.MaterialModel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class WorkCron : CronJobService
    {
        private readonly ILogger<WorkCron> _logger;
        private IMaterialService materialService;
        public WorkCron(IScheduleConfig<WorkCron> config, ILogger<WorkCron> logger,IMaterialService service)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
            this.materialService = service;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 1 starts.");
            return base.StartAsync(cancellationToken);
        }
        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} CronJob 1 is working.");
            materialService.ActiveMaterials();
            return Task.CompletedTask;
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 1 is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
