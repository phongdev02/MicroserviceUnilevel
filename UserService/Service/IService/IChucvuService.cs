using UserService.Models.Dto;

namespace UserService.Service.IService
{
    public interface IChucvuService
    {
        Task<ResponseDto?> getAllChucvu();
       /* Task<ResponseDto?> CreateChucvuAsync(ChucvuDto model);
        Task<ResponseDto?> grantPermission(int idChucvu, List<QuyenTruyCapDto> lsQuyentruycap);*/
        Task<ResponseDto?> grantAllPermission(int id);
    }
}
