using unilevel.Web.Models;

namespace unilevel.Web.Service.IService
{
    public interface INhanvienService
    {
        Task<ResponseDto?> GetListNV();
        Task<ResponseDto?> CreateNhanvien(NhanvienDtoNoID nhanvienDto);
    }
}
