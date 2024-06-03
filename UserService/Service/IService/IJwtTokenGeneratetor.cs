using UserService.Models.Dto;

namespace UserService.Service.IService
{
    public interface IJwtTokenGeneratetor
    {
        string GenerateToken(AccountDto account, List<string> roles);
        Task<AccountDto> ReadToken(string token);
    }
}
