using UCSC.SWFS.SRV.Dto;
using UCSC.SWFS.SRV.Dto.Response;

namespace UCSC.SWFS.SRV.Service.Interfaces
{
    public interface IUserService
    {
        Task<ResponseDto<List<UserDto>>> GetAllUsers();
    }
}
