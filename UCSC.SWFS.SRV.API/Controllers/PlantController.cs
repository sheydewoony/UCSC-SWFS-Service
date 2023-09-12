using Microsoft.AspNetCore.Mvc;
using UCSC.SWFS.SRV.Dto.Response;
using UCSC.SWFS.SRV.Dto;
using UCSC.SWFS.SRV.Service.Implementation;
using UCSC.SWFS.SRV.Service.Interfaces;

namespace UCSC.SWFS.SRV.API.Controllers
{
    public class PlantController : ControllerBase
    {
        private readonly IPlantService _plantService;
        public PlantController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        [HttpGet("all-plants")]
        public async Task<ResponseDto<List<PlantDto>>> GetAllPlants()
        {
            return await _plantService.GetAllPlants();
        }
        [HttpPost("plant")]
        public async Task<ResponseDto<PlantDto>> SavePlant([FromBody]PlantDto plant)
        {
            return await _plantService.SavePlant(plant);
        }
    }
}
