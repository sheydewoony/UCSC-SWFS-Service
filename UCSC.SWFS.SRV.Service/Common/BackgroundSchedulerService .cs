using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Repositories.UnitofWork;
using UCSC.SWFS.SRV.Service.Implementation;
using UCSC.SWFS.SRV.Service.Interfaces;

namespace UCSC.SWFS.SRV.Service.Common
{
    public class BackgroundSchedulerService : BackgroundService
    {
        private readonly IScheduleService _scheduleService;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public BackgroundSchedulerService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                IScheduleService _scheduleService = scope.ServiceProvider.GetService<IScheduleService>();
                // Your background logic goes here
                while (!stoppingToken.IsCancellationRequested)
                {
                    // Perform the tasks or operations you need
                    Console.WriteLine("Background service is running...");

                    await _scheduleService.StartScheduler();

                    // Delay for a certain duration before running the next iteration
                    await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
                }
            }
        }
    }
}
