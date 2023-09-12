using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Dto.Response;
using UCSC.SWFS.SRV.Dto;
using UCSC.SWFS.SRV.Service.Interfaces;
using UCSC.SWFS.SRV.Repositories.Intefaces;
using UCSC.SWFS.SRV.Entity.Entities;
using UCSC.SWFS.SRV.Repositories.Implementation;
using UCSC.SWFS.SRV.Utilities.Resources;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Numerics;
using Microsoft.EntityFrameworkCore.Metadata;
using UCSC.SWFS.SRV.Repositories.UnitofWork;

namespace UCSC.SWFS.SRV.Service.Implementation
{
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        public PlantService(IPlantRepository plantRepository, IMapper mapper, IUnitofWork unitofWork)
        {
            _plantRepository = plantRepository;
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<PlantDto>>> GetAllPlants()
        {
            ResponseDto<List<PlantDto>> plantResponseDto = new ResponseDto<List<PlantDto>>();
            plantResponseDto.ErrorList = new List<ErrorInfoDto>();
            try
			{               
                List<Plant> plants = await _plantRepository.GetAll().ToListAsync();
                if (plants != null && plants.Count > 0)
                {
                    var plantDtoList = _mapper.Map<List<PlantDto>>(plants);
                    plantResponseDto.ResultData = plantDtoList;
                }
                else
                {
                    plantResponseDto.ResultData = null;
                }
            }
			catch (Exception ex)
			{
                plantResponseDto.ErrorList.Add(new ErrorInfoDto
                {
                    ErrorCode = "SMFS_ERR_02",
                    ErrorMessage = UserResource.SMFS_ERR_02
                 });
                throw ex;
            }
            return plantResponseDto;
        }

        public async Task<ResponseDto<PlantDto>> SavePlant(PlantDto plant)
        {
            ResponseDto<PlantDto> plantResponseDto = new ResponseDto<PlantDto>();
            plantResponseDto.ErrorList = new List<ErrorInfoDto>();
            try
            {
                _unitofWork.Begin();
                var plantEntity = _mapper.Map<Plant>(plant);
                var savedPlant = await _plantRepository.InsertAsync(plantEntity);
                await _unitofWork.SaveChangesAsync();
                if (savedPlant != null)
                {
                    var savedPlantDto = _mapper.Map<PlantDto>(savedPlant);
                    plantResponseDto.ResultData = savedPlantDto;
                    _unitofWork.Commit();
                }
                else
                {
                    plantResponseDto.ResultData = null;
                }
            }
            catch (Exception ex)
            {
                plantResponseDto.ErrorList.Add(new ErrorInfoDto
                {
                    ErrorCode = "SMFS_ERR_03",
                    ErrorMessage = UserResource.SMFS_ERR_03
                });
                _unitofWork.Rollback();
                throw ex;
            }
            return plantResponseDto;
        }
    }
}
