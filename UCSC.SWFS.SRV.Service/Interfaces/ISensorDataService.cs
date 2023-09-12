using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Dto;

namespace UCSC.SWFS.SRV.Service.Interfaces
{
    public interface ISensorDataService
    {
        Task SaveSensorData(SensorValueDto sensorValueDto);
    }
}
