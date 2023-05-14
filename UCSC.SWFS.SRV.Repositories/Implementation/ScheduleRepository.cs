using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Entity.Entities.UserManagemen;
using UCSC.SWFS.SRV.Repositories.Intefaces;
using UCSC.SWFS.SRV.Repositories.UnitofWork;

namespace UCSC.SWFS.SRV.Repositories.Implementation
{
    public class ScheduleRepository : BaseRepository<Schedule> , IScheduleRepository
    {
        private IUnitofWork _unitOfWork = null;

        public ScheduleRepository(IUnitofWork unitOfWork) :base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
