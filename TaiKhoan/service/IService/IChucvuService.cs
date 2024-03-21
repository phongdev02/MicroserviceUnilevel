using TaiKhoan.Models;
using TaiKhoan.Models.Dto;

namespace TaiKhoan.service.IService
{
    public interface IChucvuService
    {
        Task<ResponseDto?> CreateChucvuAsync(ChucvuDto model);
        Task<ResponseDto?> grantPermission(int idChucvu,List<QuyenTruyCapDto> lsQuyentruycap);
        Task<ResponseDto?> grantAllPermission(int id);

    }
}
