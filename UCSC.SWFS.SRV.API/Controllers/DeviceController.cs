using Microsoft.AspNetCore.Mvc;
using UCSC.SWFS.SRV.Dto.Response;
using UCSC.SWFS.SRV.Dto;
using UCSC.SWFS.SRV.Service.Implementation;
using UCSC.SWFS.SRV.Service.Interfaces;

namespace UCSC.SWFS.SRV.API.Controllers
{
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;
        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }
        [HttpGet("all-device")]
        public async Task<ResponseDto<List<DeviceDto>>> GetAllPlants()
        {
            return await _deviceService.GetAllDevices();
        }
        [HttpPost("device")]
        public async Task<ResponseDto<DeviceDto>> SavePlant([FromBody] DeviceDto device)
        {
            return await _deviceService.SaveDevice(device);
        }
    }
}
