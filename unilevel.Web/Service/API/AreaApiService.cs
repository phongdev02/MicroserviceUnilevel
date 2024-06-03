using Newtonsoft.Json;
using unilevel.Web.Models;
using unilevel.Web.Service.IAPI;
using unilevel.Web.Service.IService;
using unilevel.Web.Utility;

namespace unilevel.Web.Service.API
{
    public class AreaApiService : IAreaApiService
    {
        private readonly IBaseService _baseService;
        private ResponseDto _responseDto;
        public AreaApiService(IBaseService baseService)
        {
            _baseService = baseService;
            _responseDto = new ResponseDto();
        }

        public async Task<ResponseDto?> AddAreaAsync(AreaDto model)
        {
            var responseDto = await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = model,
                Url = SD.UserApiBase + "/api/Area/AddAreaAsync"
            });

            if (responseDto != null && responseDto.IsSuccess == true)
            {
                var result = JsonConvert.DeserializeObject<AreaDto>(Convert.ToString(responseDto.Result));
                responseDto.Result = result;
            }

            return responseDto;

        }

        public async Task<ResponseDto?> DeleteAreaAsync(string areacode)
        {
            var responseDto = await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.UserApiBase + "/api/Area/DeleteAreaAsync/" + areacode
            });

            if (responseDto != null && responseDto.IsSuccess == true)
            {
                var result = JsonConvert.DeserializeObject<AreaDto>(Convert.ToString(responseDto.Result));
                responseDto.Result = result;
            }

            return responseDto;
        }

        public async Task<ResponseDto?> EditAreaAsync(AreaDto model)
        {
            var responseDto  = await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = model,
                Url = SD.UserApiBase + "/api/Area/EditAreaAsync"
            });
            if (responseDto != null && responseDto.IsSuccess == true)
            {
                var result = JsonConvert.DeserializeObject<AreaDto>(Convert.ToString(responseDto.Result));
                responseDto.Result = result;
            }

            return responseDto;
        }

        public async Task<ResponseDto?> FindAreaAsync(string inputSearch)
        {
            var responseDto = await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserApiBase + "/api/Area/FindAreaAsync/" + inputSearch
            });

            if (responseDto != null && responseDto.IsSuccess == true)
            {
                var result = JsonConvert.DeserializeObject<List<AreaViewDto>>(Convert.ToString(responseDto.Result));
                responseDto.Result = result;
            }

            return responseDto;
        }

        public async Task<ResponseDto?> GetAreaAsync(string areacode)
        {
            var responseDto = await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserApiBase + "/api/Area/GetAreaAsync/" + areacode
            });

            if (responseDto != null && responseDto.IsSuccess == true)
            {
                var result = JsonConvert.DeserializeObject<AreaViewDto>(Convert.ToString(responseDto.Result));
                responseDto.Result = result;
            }

            return responseDto;
        }

        public async Task<ResponseDto?> GetAreasAsync()
        {
            var responseDto = await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserApiBase + "/api/Area/GetAreasAsync"
            });

            if (responseDto != null && responseDto.IsSuccess == true)
            {
                var result = JsonConvert.DeserializeObject<List<AreaViewDto>>(Convert.ToString(responseDto.Result));
                responseDto.Result = result;
            }

            return responseDto;
        }
    }
}
