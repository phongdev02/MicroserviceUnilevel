using UserService.Models.Dto;

namespace UserService.Service.IService
{
    public interface IRoleService
    {
        Task<ResponseDto?> GetListRole(int accoutID);
    }
}
