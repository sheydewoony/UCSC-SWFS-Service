using AutoMapper;
using Microsoft.AspNetCore.SignalR;
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
using UCSC.SWFS.SRV.Service.Common.SignalIR;
using UCSC.SWFS.SRV.Service.Interfaces;
using UCSC.SWFS.SRV.Utilities.Resources;

namespace UCSC.SWFS.SRV.Service.Implementation
{
    public class SensorDataService : ISensorDataService
    {
        private readonly ISensorDataRepository _sensorDataRepository;
        private readonly IPlantRepository _plantRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IHubContext<SensorDataHub> _sensorHubContext;
        public SensorDataService(
            ISensorDataRepository sensorDataRepository, 
            IUnitofWork unitofWork, 
            IMapper mapper,
            IPlantRepository plantRepository, 
            IDeviceRepository deviceRepository,
            IHubContext<SensorDataHub> sensorHubContext
            )
        {
            _sensorDataRepository = sensorDataRepository;
            _unitofWork = unitofWork;
            _mapper = mapper;
            _plantRepository = plantRepository;
            _deviceRepository = deviceRepository;
            _sensorHubContext = sensorHubContext;
        }

        public async Task SaveSensorData(SensorValueDto sensorValueDto)
        {
            try
            {
                _unitofWork.Begin();
                var sensorDataEntity = _mapper.Map<SensorData>(sensorValueDto);

                if(sensorDataEntity != null)
                {
                 Device device =  await _deviceRepository.GetAll().Where(x => x.Port == sensorValueDto.Port)?.FirstOrDefaultAsync();
                 Plant plant = await _plantRepository.GetAll().Where(x => x.PlantId == device.PlantId)?.FirstOrDefaultAsync();
                    if (device != null && plant != null)
                    {
                        sensorDataEntity.PlantID = plant.PlantId;
                        sensorDataEntity.DeviceId = device.DeviceId;
                        sensorDataEntity.DeviceType = device.DeviceType;

                        var existEntity = await _sensorDataRepository.GetAll().Where(x => x.DeviceId == device.DeviceId && x.PlantID == plant.PlantId)?.FirstOrDefaultAsync();

                        if (existEntity != null)
                        {
                            existEntity.Value = sensorValueDto.Value;
                            existEntity.ModifiedOn = DateTime.UtcNow;
                            await _unitofWork.SaveChangesAsync();
                            var savedPlantDto = _mapper.Map<SensorDataDto>(existEntity);
                            await _sensorHubContext.Clients.All.SendAsync("ReceiveSensorData", savedPlantDto);
                        }
                        else
                        {
                            var savedEntity = await _sensorDataRepository.InsertAsync(sensorDataEntity);
                            await _unitofWork.SaveChangesAsync();
                            if (savedEntity != null)
                            {
                                var savedPlantDto = _mapper.Map<SensorDataDto>(savedEntity);
                                //publish to socket
                                await _sensorHubContext.Clients.All.SendAsync("ReceiveSensorData", savedPlantDto);
                            }
                        }
                        _unitofWork.Commit();
                    }       
                }
            }
            catch (Exception ex)
            {
                _unitofWork.Rollback();
                throw ex;
            }
        }
    }
}
