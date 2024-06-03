using Microsoft.AspNetCore.Mvc;
using unilevel.Web.Models;

namespace unilevel.Web.Service.IService
{
    public interface IAccountService
    {
        Task<ResponseDto?> CreateAccountAsync([FromBody] AccountDtoNoID model);
        Task<ResponseDto?> AccountSearchAsync(String search);
        Task<ResponseDto?> LogginAccountAsync(LoginDto model);
        Task<ResponseDto?> ReadTokenAsync(string token);
    }
}
