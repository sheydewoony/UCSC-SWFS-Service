using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Entity.Entities;
using UCSC.SWFS.SRV.Repositories.Intefaces;
using UCSC.SWFS.SRV.Repositories.UnitofWork;

namespace UCSC.SWFS.SRV.Repositories.Implementation
{
    public class PlantRepository : BaseRepository<Plant>, IPlantRepository
    {
        private IUnitofWork _unitOfWork = null;

        public PlantRepository(IUnitofWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
