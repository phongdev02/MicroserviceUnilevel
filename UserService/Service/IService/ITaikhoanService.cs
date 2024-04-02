using Microsoft.AspNetCore.Mvc;
using UserService.Models.Dto;

namespace UserService.Service.IService
{
    public interface ITaikhoanService
    {
        Task<ResponseDto> GetListNhanVat();
        Task<ResponseDto> LogginAccount(string gmail, string pass);
        Task<ResponseDto> EditPass(int id, string passOld, string passNew);
        Task<ResponseDto> CreateAccount([FromBody] NhanvienDtoNoID nhanvienDtoNoID);
        Task<ResponseDto> EditAccount([FromBody] NhanvienDtoNoID nhanvienDtoNoID);
        Task<ResponseDto> StatusAccount(int id);

    }
}
