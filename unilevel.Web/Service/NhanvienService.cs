using unilevel.Web.Service.IService;
using unilevel.Web.Models;
using unilevel.Web.Utility;

namespace unilevel.Web.Service
{
    public class NhanvienService : INhanvienService
    {
        private readonly IBaseService _baseService;
        public NhanvienService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> GetListNV()
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserApiBase + "/api/NhanvienAPI"
            });
        }

        public async Task<ResponseDto?> CreateNhanvien(NhanvienDtoNoID nhanvienDto)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = nhanvienDto,
                Url = SD.UserApiBase + "/api/NhanvienAPI/"
            });
        }
    }
}
