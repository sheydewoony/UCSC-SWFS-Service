using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UCSC.SWFS.SRV.Entity.Entities
{
    public class SensorData : AuditFields
    {
        [Key]
        public int SensorDataID { get; set; }
        public int DeviceId { get; set; }
        public string DeviceType { get; set; }
        public int Port { get; set; }
        public int PlantID { get; set; }
        public double Value { get; set; }

    }
}
