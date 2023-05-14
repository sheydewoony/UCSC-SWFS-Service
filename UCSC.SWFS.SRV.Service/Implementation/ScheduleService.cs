using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Repositories.Intefaces;
using UCSC.SWFS.SRV.Service.Common;
using UCSC.SWFS.SRV.Service.Interfaces;

namespace UCSC.SWFS.SRV.Service.Implementation
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMQTTBrockerService _MQTTBrockerService;
        public ScheduleService(IScheduleRepository scheduleRepository, IMQTTBrockerService MQTTBrockerService)
        {
            _scheduleRepository = scheduleRepository;
            _MQTTBrockerService = MQTTBrockerService;
        }

        public async Task StartScheduler()
        {
            var scheduleList =  await _scheduleRepository.GetAll().Include(x=>x.Tasks).ThenInclude(x=>x.Device).ToListAsync();
            List<Task> taskTasks = new List<Task>();
            if(scheduleList != null && scheduleList.Count > 0)
            {
                foreach (var schedule in scheduleList)
                {
                    foreach(var task in schedule.Tasks)
                    {
                        taskTasks.Add(_MQTTBrockerService.PublishMessageToMqttBroker("SWFS/"+ task.DeviceId.ToString(),task.Volume.ToString()));
                    }
                }
                await Task.WhenAll(taskTasks);
            }
        }
    }
}
