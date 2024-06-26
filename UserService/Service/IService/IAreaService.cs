﻿using UserService.Models;
using UserService.Models.Dto;

namespace UserService.Service.IService
{
    public interface IAreaService
    {
        Task<ResponseDto> GetAreasAsync();
        Task<ResponseDto> GetAreaAsync(string areacode);
        Task<ResponseDto> AddAreaAsync(AreaDto model);
        Task<ResponseDto> DeleteAreaAsync(string areacode);
        Task<ResponseDto> FindAreaAsync(string inputSearch);
        Task<ResponseDto> EditAreaAsync(AreaDto model);
    }
}
