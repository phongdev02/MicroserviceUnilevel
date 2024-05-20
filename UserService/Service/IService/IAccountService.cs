using Microsoft.AspNetCore.Mvc;
using UserService.Models.Dto;

namespace UserService.Service.IService
{
    public interface IAccountService
    {
        Task<ResponseDto?> CreateAccount([FromBody] AccountDtoNoID model, int? managementID);
        Task<ResponseDto?> AccountSearch(String search);
        Task<ResponseDto?> LogginAccount(string gmail, string pass);
    }
}
