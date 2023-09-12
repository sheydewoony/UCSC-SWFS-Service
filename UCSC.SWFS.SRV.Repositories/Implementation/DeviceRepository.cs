using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Entity.Entities;
using UCSC.SWFS.SRV.Repositories.Intefaces;
using UCSC.SWFS.SRV.Repositories.UnitofWork;

namespace UCSC.SWFS.SRV.Repositories.Implementation
{
    public class DeviceRepository :  BaseRepository<Device>, IDeviceRepository
    {
        private IUnitofWork _unitOfWork = null;

        public DeviceRepository(IUnitofWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
