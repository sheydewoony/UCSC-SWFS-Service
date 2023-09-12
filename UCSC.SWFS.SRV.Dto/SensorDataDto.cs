using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Entity.Entities;

namespace UCSC.SWFS.SRV.Dto
{
    public class SensorDataDto
    {
            public int DeviceID { get; set; }
            public string DeviceType { get; set; }
            public int PlantID { get; set; }            
            public double Value { get; set; }
        
    }
}
