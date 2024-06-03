using Newtonsoft.Json;
using unilevel.Web.Models;
using unilevel.Web.Service.IAPI;
using unilevel.Web.Service.IService;

namespace unilevel.Web.Service
{
    public class AreaService : IAreaService
    {
        private readonly IAreaApiService _areaApiService;
        public AreaService(IAreaApiService areaApiService)
        {
            _areaApiService = areaApiService;
        }

        public async Task<ResponseDto?> AddAreaAsync(AreaDto model)
        {
            ResponseDto? response = await _areaApiService.AddAreaAsync(model);

            if (response != null && response.IsSuccess == true)
            {
                var lst = JsonConvert.DeserializeObject<AreaDto>(Convert.ToString(response.Result));
                response.Result = lst;
            }

            return response;
        }

        public async Task<ResponseDto?> DeleteAreaAsync(string areacode)
        {
            ResponseDto? response = await _areaApiService.DeleteAreaAsync(areacode);

            if (response != null && response.IsSuccess == true)
            {
                var lst = JsonConvert.DeserializeObject<AreaDto>(Convert.ToString(response.Result));
                response.Result = lst;
            }

            return response;
        }

        public async Task<ResponseDto?> EditAreaAsync(AreaDto model)
        {
            ResponseDto? response = await _areaApiService.EditAreaAsync(model);

            if (response != null && response.IsSuccess == true)
            {
                var lst = JsonConvert.DeserializeObject<AreaDto>(Convert.ToString(response.Result));
                response.Result = lst;
            }

            return response;
        }

        public async Task<ResponseDto?> FindAreaAsync(string inputSearch)
        {
            ResponseDto? response = await _areaApiService.FindAreaAsync(inputSearch);

            if (response != null && response.IsSuccess == true)
            {
                var lst = JsonConvert.DeserializeObject<AreaDto>(Convert.ToString(response.Result));
                response.Result = lst;
            }

            return response;
        }

        public async Task<ResponseDto?> GetAreaAsync(string areacode)
        {
            ResponseDto? response = await _areaApiService.GetAreaAsync(areacode);

            if (response != null && response.IsSuccess == true)
            {
                var lst = JsonConvert.DeserializeObject<AreaDto>(Convert.ToString(response.Result));
                response.Result = lst;
            }

            return response;
        }

        public async Task<ResponseDto?> GetAreasAsync()
        {
            ResponseDto? response = await _areaApiService.GetAreasAsync();

            if (response != null && response.IsSuccess == true)
            {
                var lst = JsonConvert.DeserializeObject<AreaDto>(Convert.ToString(response.Result));
                response.Result = lst;
            }

            return response;
        }
    }
}
