using TaiKhoan.Models.Dto;

namespace TaiKhoan.service.IService
{
    public interface ITaikhoanService
    {
        Task<NhanvienDto> LogginAccount();
        Task<NhanvienDto> EditPass();
        Task<NhanvienDto> CreateAccount();
        Task<NhanvienDto> EditAccount();
    }
}
