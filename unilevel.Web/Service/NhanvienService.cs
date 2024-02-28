using TaiKhoan.Models.Dto;
using unilevel.Web.Models;
using unilevel.Web.Service.IService;
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

        public async Task<ResponseDto?> CreateNhanvienAsync(NhanvienDto nhanvienDto)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = nhanvienDto,
                Url = SD.NhanvienApiBase + "/api/NhanvienAPI"

            });
        }

        public async Task<ResponseDto?> DeleteAllNhanvienAsync(int id)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.NhanvienApiBase + "/api/NhanvienAPI/Delete/" + id

            });
        }

        public async Task<ResponseDto?> GetAllNhanvienAsync(string gmail)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.NhanvienApiBase + "/api/NhanvienAPI/GetByGmail/" + gmail

            });
        }

        public async Task<ResponseDto?> GetNhanvienAsync()
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.NhanvienApiBase + "/api/NhanvienAPI"

            });
        }

        public async Task<ResponseDto?> GetNhanvienByIDAsync(int id)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.NhanvienApiBase + "/api/NhanvienAPI/" + id

            });
        }

        public async Task<ResponseDto?> UpdateNhanvienAsync(NhanvienDto nhanvienDto)
        {
            return await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data= nhanvienDto,
                Url = SD.NhanvienApiBase + "/api/NhanvienAPI/GetByGmail"
            });
        }
    }
}
