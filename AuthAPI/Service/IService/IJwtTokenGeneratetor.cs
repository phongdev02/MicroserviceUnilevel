using AuthAPI.Models;

namespace AuthAPI.Service.IService
{
    public interface IJwtTokenGeneratetor
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string>  roles);
    }
}
