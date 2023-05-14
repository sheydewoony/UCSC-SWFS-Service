using Microsoft.AspNetCore.Mvc;
using UCSC.SWFS.SRV.Dto;
using UCSC.SWFS.SRV.Dto.Response;
using UCSC.SWFS.SRV.Service.Interfaces;

namespace UCSC.SWFS.SRV.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-all-users")]
        public async Task<ResponseDto<List<UserDto>>> GetAllUsers()
        {
            try
            {
                return await _userService.GetAllUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
