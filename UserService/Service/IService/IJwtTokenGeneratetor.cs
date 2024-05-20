using UserService.Models.Dto;

namespace UserService.Service.IService
{
    public interface IJwtTokenGeneratetor
    {
        string GenerateToken(AccountDto account, string roles);
    }
}
