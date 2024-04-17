using unilevel.Web.Models;

namespace unilevel.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SenAsync(RequestDto requestDto);

    }
}
