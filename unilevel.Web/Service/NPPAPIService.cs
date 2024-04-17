using unilevel.Web.Models;
using unilevel.Web.Service.IService;
using unilevel.Web.Utility;

namespace unilevel.Web.Service
{
    public class NPPAPIService : INPPAPIService
    {
        private readonly IBaseService _baseService;
        private ResponseDto _responseDto;
        public NPPAPIService(IBaseService baseService)
        {
            _baseService = baseService;
            _responseDto = new ResponseDto();
        }

        public async Task<ResponseDto?> createNPP(NhaPhanPhoiDto model)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = model,
                Url = SD.UserApiBase + "/api/NPP/createNPP"
            });
        }

        public async Task<ResponseDto?> deleteNPP(int id)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.UserApiBase + "/api/NPP/deleteNPP/" + id
            });
        }

        public async Task<ResponseDto?> findNPP(int id)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserApiBase + "/api/NPP/findNPP/" + id
            });
        }

        public async Task<ResponseDto?> getListNPP()
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserApiBase + "/api/NPP/getListNPP"
            });
        }

        public async Task<ResponseDto?> getListNPPWithCodeArea(string code)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserApiBase + "/api/NPP/getListNPPWithCodeArea/"+code
            });
        }

        public async Task<ResponseDto?> getNPPTemplate(string code)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserApiBase + "/api/NPP/getNPPTemplate/"+code
            });
        }

        public async Task<ResponseDto?> updateNPP(NhaPhanPhoiDto model)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = model,
                Url = SD.UserApiBase + "/api/NPP/updateNPP"
            });
        }
    }
}
