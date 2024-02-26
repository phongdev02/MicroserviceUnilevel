using TaiKhoan.Models.Dto;
using unilevel.Web.Models;
using unilevel.Web.Service.IService;

namespace unilevel.Web.Service
{
    public class NhanvienService : INhanvienService
    {
        private readonly IBaseService _baseService;
        public NhanvienService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<ResponseDto?> CreateNhanvienAsync(NhanvienDto nhanvienDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> DeleteAllNhanvienAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetAllNhanvienAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetNhanvienAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetNhanvienByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateNhanvienAsync(NhanvienDto nhanvienDto)
        {
            throw new NotImplementedException();
        }
    }
}
