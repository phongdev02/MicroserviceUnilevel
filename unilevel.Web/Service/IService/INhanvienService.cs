using TaiKhoan.Models.Dto;
using unilevel.Web.Models;

namespace unilevel.Web.Service.IService
{
    public interface INhanvienService
    {
        Task<ResponseDto?> GetNhanvienAsync();
        Task<ResponseDto?> GetAllNhanvienAsync(string gmail);
        Task<ResponseDto?> GetNhanvienByIDAsync(int id);
        Task<ResponseDto?> CreateNhanvienAsync(NhanvienDto nhanvienDto);
        Task<ResponseDto?> UpdateNhanvienAsync(NhanvienDto nhanvienDto);
        Task<ResponseDto?> DeleteAllNhanvienAsync(int id);
    }
}
