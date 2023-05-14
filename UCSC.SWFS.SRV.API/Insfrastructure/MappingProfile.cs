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
        }
    }
}
