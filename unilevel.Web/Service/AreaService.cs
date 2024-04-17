using Newtonsoft.Json;
using unilevel.Web.Models;
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

        public async Task<ResponseDto?> AddArea(KhuvucDto model)
        {
            ResponseDto? response = await _areaApiService.AddArea(model);

            if (response != null && response.IsSuccess == true)
            {
                var lst = JsonConvert.DeserializeObject<KhuvucDto>(Convert.ToString(response.Result));
                response.Result = lst;
            }

            return response;
        }

        public async Task<ResponseDto?> DeleteArea(string KhuvucID)
        {
            ResponseDto? response = await _areaApiService.DeleteArea(KhuvucID);

            if (response != null && response.IsSuccess == true)
            {
                var lst = JsonConvert.DeserializeObject<KhuvucDto>(Convert.ToString(response.Result));
                response.Result = lst;
            }

            return response;
        }

        public async Task<ResponseDto?> EditArea(KhuvucDto model)
        {
            ResponseDto? response = await _areaApiService.EditArea(model);

            if (response != null && response.IsSuccess == true)
            {
                var lst = JsonConvert.DeserializeObject<KhuvucDto>(Convert.ToString(response.Result));
                response.Result = lst;
            }

            return response;
        }

        public async Task<ResponseDto?> FindArea(string inputSearch)
        {
            ResponseDto? response = await _areaApiService.FindArea(inputSearch);

            if (response != null && response.IsSuccess == true)
            {
                var lst = JsonConvert.DeserializeObject<AreaViewDto>(Convert.ToString(response.Result));
                response.Result = lst;
            }

            return response;
        }

        public async Task<ResponseDto?> GetArea(string khuvucID)
        {
            ResponseDto? response = await _areaApiService.GetArea(khuvucID);

            if (response != null && response.IsSuccess == true)
            {
                var lst = JsonConvert.DeserializeObject<AreaViewDto>(Convert.ToString(response.Result));
                response.Result = lst;
            }

            return response;
        }

        public async Task<ResponseDto?> GetAreas()
        {
            ResponseDto? response = await _areaApiService.GetAreas();

            if (response != null && response.IsSuccess == true)
            {
                var lst = JsonConvert.DeserializeObject<AreaViewDto>(Convert.ToString(response.Result));
                response.Result = lst;
            }

            return response;
        }
    }
}
