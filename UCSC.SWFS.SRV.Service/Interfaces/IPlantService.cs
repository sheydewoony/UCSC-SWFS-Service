using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Dto;
using UCSC.SWFS.SRV.Dto.Response;

namespace UCSC.SWFS.SRV.Service.Interfaces
{
    public interface IPlantService
    {
        Task<ResponseDto<List<PlantDto>>> GetAllPlants();
        Task<ResponseDto<PlantDto>> SavePlant(PlantDto plant);
    }
}
