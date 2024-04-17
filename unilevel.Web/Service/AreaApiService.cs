using unilevel.Web.Models;
using unilevel.Web.Service.IService;
using unilevel.Web.Utility;

namespace unilevel.Web.Service
{
    public class AreaApiService : IAreaApiService
    {
        private readonly IBaseService _baseService;
        public AreaApiService(IBaseService baseService) 
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> AddArea(KhuvucDto model)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = model,
                Url = SD.UserApiBase + "/api/Area/AddArea"
            });
        }

        public async Task<ResponseDto?> DeleteArea(string KhuvucID)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.UserApiBase + "/api/Area/DeleteArea/" + KhuvucID
            });
        }

        public async Task<ResponseDto?> EditArea(KhuvucDto model)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = model,
                Url = SD.UserApiBase + "/api/Area/EditArea"
            });
        }

        public async Task<ResponseDto?> FindArea(string inputSearch)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserApiBase + "/api/Area/FindArea/" + inputSearch
            });
        }

        public async Task<ResponseDto?> GetArea(string khuvucID)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserApiBase + "/api/Area/GetArea/" + khuvucID
            });
        }

        public async Task<ResponseDto?> GetAreas()
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserApiBase + "/api/Area/GetArea"
            });
        }
    }
}
