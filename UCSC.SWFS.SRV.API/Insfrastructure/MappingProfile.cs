using AutoMapper;
using UCSC.SWFS.SRV.Dto;
using UCSC.SWFS.SRV.Entity.Entities;

namespace UCSC.SWFS.SRV.API.Insfrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<Plant, PlantDto>();
            CreateMap<PlantDto, Plant>();
            CreateMap<Device, DeviceDto>();
            CreateMap<DeviceDto, Device>();
            CreateMap<SensorData, SensorValueDto>();
            CreateMap<SensorValueDto, SensorData>();
            CreateMap<SensorDataDto, SensorData>();
            CreateMap<SensorData, SensorDataDto>();
        }
    }
}
