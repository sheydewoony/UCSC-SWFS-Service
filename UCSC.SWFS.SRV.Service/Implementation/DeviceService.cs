using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Dto;
using UCSC.SWFS.SRV.Dto.Response;
using UCSC.SWFS.SRV.Entity.Entities;
using UCSC.SWFS.SRV.Repositories.Implementation;
using UCSC.SWFS.SRV.Repositories.Intefaces;
using UCSC.SWFS.SRV.Repositories.UnitofWork;
using UCSC.SWFS.SRV.Service.Interfaces;
using UCSC.SWFS.SRV.Utilities.Resources;

namespace UCSC.SWFS.SRV.Service.Implementation
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _devicetRepository;
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        public DeviceService(IDeviceRepository devicetRepository, IUnitofWork unitofWork, IMapper mapper)
        {
            _devicetRepository = devicetRepository;
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<DeviceDto>>> GetAllDevices()
        {
            ResponseDto<List<DeviceDto>> deviceResponseDto = new ResponseDto<List<DeviceDto>>();
            deviceResponseDto.ErrorList = new List<ErrorInfoDto>();
            try
            {
                List<Device> devices = await _devicetRepository.GetAll().ToListAsync();
                if (devices != null && devices.Count > 0)
                {
                    var plantDtoList = _mapper.Map<List<DeviceDto>>(devices);
                    deviceResponseDto.ResultData = plantDtoList;
                }
                else
                {
                    deviceResponseDto.ResultData = null;
                }
            }
            catch (Exception ex)
            {
                deviceResponseDto.ErrorList.Add(new ErrorInfoDto
                {
                    ErrorCode = "SMFS_ERR_04",
                    ErrorMessage = UserResource.SMFS_ERR_04
                });
                throw ex;
            }
            return deviceResponseDto;
        }

        public async Task<ResponseDto<DeviceDto>> SaveDevice(DeviceDto plant)
        {
            ResponseDto<DeviceDto> deviceResponseDto = new ResponseDto<DeviceDto>();
            deviceResponseDto.ErrorList = new List<ErrorInfoDto>();
            try
            {
                _unitofWork.Begin();
                var deviceEntity = _mapper.Map<Device>(plant);
                var savedDevice = await _devicetRepository.InsertAsync(deviceEntity);
                await _unitofWork.SaveChangesAsync();
                if (savedDevice != null)
                {
                    var savedDeviceDto = _mapper.Map<DeviceDto>(savedDevice);
                    deviceResponseDto.ResultData = savedDeviceDto;
                    _unitofWork.Commit();
                }
                else
                {
                    deviceResponseDto.ResultData = null;
                }
            }
            catch (Exception ex)
            {
                deviceResponseDto.ErrorList.Add(new ErrorInfoDto
                {
                    ErrorCode = "SMFS_ERR_05",
                    ErrorMessage = UserResource.SMFS_ERR_05
                });
                _unitofWork.Rollback();
                throw ex;
            }
            return deviceResponseDto;
        }
    }
}
