using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSC.SWFS.SRV.Service.Interfaces
{
    public interface IScheduleService
    {
        Task StartScheduler();
    }
}
