using System.ComponentModel.DataAnnotations;

namespace UCSC.SWFS.SRV.Entity.Entities
{
    public class PlantTask : AuditFields
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public int ScheduleId { get; set; }
        [Required]
        public int DeviceId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? NextIterationTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan Interval { get; set; }
        public int Volume { get; set; }
        public string Status { get; set; }
        public Device Device { get; set; }
    }
}
