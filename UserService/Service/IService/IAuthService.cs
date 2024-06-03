using Microsoft.AspNetCore.Mvc;
using UserService.Models.Dto;

namespace UserService.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto?> SendEmailActiveAsync([FromBody] MailContextDto mailContextDto);
        Task<ResponseDto?> LogginAccountAsync([FromBody] LoginDto login);
        Task<ResponseDto?> ReadTokenAsync(string token);
    }
}
