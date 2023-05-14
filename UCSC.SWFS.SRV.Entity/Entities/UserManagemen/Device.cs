using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSC.SWFS.SRV.Entity.Entities.UserManagemen
{
    public class Device : AuditFields
    {
        [Key]
        public int DeviceId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public string? Configuration { get; set; }
        public bool IsOnline { get; set; }
        public List<Task>? Tasks { get; set; }
    }
}
