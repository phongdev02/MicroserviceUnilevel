using Microsoft.AspNetCore.Mvc;
using unilevel.Web.Models;

namespace unilevel.Web.Service.IAPI
{
    public interface IAccountAPIService
    {
        Task<ResponseDto?> CreateAccountAsync([FromBody] AccountDtoNoID model);
        Task<ResponseDto?> AccountSearchAsync(String search);
        Task<ResponseDto?> LogginAccountAsync([FromBody]LoginDto model);
        Task<ResponseDto?> ReadTokenAsync(string token);
        Task<ResponseDto?> SendEmailAsync([FromBody] MailContextDto mailContext, HttpRequest request);
    }
}
