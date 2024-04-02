using TaiKhoan.Models.Dto;
using unilevel.Web.Models;
using unilevel.Web.Models.Dto;

namespace unilevel.Web.Service.IService
{
    public interface INhanvienService
    {
        Task<ResponseDto?> GetListNV();
        Task<ResponseDto?> CreateNhanvien(NhanvienDtoNoID nhanvienDto);
    }
}
