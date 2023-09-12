using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSC.SWFS.SRV.Entity.Entities
{
    public class Device : AuditFields
    {
        [Key]
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
