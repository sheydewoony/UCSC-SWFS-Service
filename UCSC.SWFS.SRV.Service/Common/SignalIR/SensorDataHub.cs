using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Dto;

namespace UCSC.SWFS.SRV.Service.Common.SignalIR
{
    public class SensorDataHub : Hub
    {
        public async Task SendSensorData(SensorDataDto sensorDataDto)
        {
            await Clients.All.SendAsync("ReceiveSensorData", sensorDataDto);
        }
    }
}
