using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Entity.Entities;

namespace UCSC.SWFS.SRV.Dto
{
    public class DeviceDto : AuditFields
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string Unit { get; set; }
        public int PlantId { get; set; }
        public int Port { get; set; }
        public float MinValue { get; set; }
        public float MaxValue { get; set; }
        public string Status { get; set; }
    }
}
