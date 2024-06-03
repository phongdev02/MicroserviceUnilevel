using Microsoft.AspNetCore.Mvc;
using UserService.Models.Dto;

namespace UserService.Service.IService
{
    public interface IAccountService
    {
        Task<ResponseDto> StatusAccountAsync(int id);
        Task<ResponseDto?> CreateAccountAsync([FromBody] AccountDtoNoID model);
        Task<ResponseDto?> EditAccountAsync([FromBody] AccountDtoNoID model);
        Task<ResponseDto?> AccountSearchAsync(String search);
        Task<ResponseDto?> GetLsAccountAsync();
        Task<ResponseDto?> GetAccountAsync(int accid);
        Task<ResponseDto?> DeleteAccountAsync(int accid);
    }
}
