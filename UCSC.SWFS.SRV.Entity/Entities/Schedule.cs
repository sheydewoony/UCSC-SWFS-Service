using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSC.SWFS.SRV.Entity.Entities
{
    public class Schedule : AuditFields
    {
        [Key]
        public int ScheduleId { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public List<PlantTask> PlantTasks { get; set; }
    }
}
