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
using UCSC.SWFS.SRV.Repositories.Intefaces;
using UCSC.SWFS.SRV.Service.Common;
using UCSC.SWFS.SRV.Service.Interfaces;
using UCSC.SWFS.SRV.Utilities.Resources;

namespace UCSC.SWFS.SRV.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMQTTBrockerService _MQTTBrockerService;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper, IMQTTBrockerService mQTTBrockerService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _MQTTBrockerService = mQTTBrockerService;
        }
        public async Task<ResponseDto<List<UserDto>>> GetAllUsers()
        {
            ResponseDto<List<UserDto>> usersResponseDto = new ResponseDto<List<UserDto>>();
            usersResponseDto.ErrorList = new List<ErrorInfoDto>();
            try
            {
                await _MQTTBrockerService.PublishMessageToMqttBroker("testtopic/injector1", "{\r\n  \"msg\": \"hello\"\r\n}");
                List<User> users = await _userRepository.GetAll().ToListAsync();                
                if (users != null && users.Count > 0)
                {
                    var usersDtoList = _mapper.Map<List<UserDto>>(users);
                    usersResponseDto.ResultData = usersDtoList;
                }
                else
                {
                    usersResponseDto.ResultData = null;
                    usersResponseDto.MessageCode = "SMFS_ERR_01";
                    usersResponseDto.Message = UserResource.SMFS_ERR_01;
                }
            }
            catch (Exception ex)
            {
                usersResponseDto.ErrorList.Add(new ErrorInfoDto
                {
                    ErrorCode = "SMFS_ERR_01",
                    ErrorMessage = UserResource.SMFS_ERR_01
                }) ;
                throw ex;
            }
            return usersResponseDto;
        }
    }
}
