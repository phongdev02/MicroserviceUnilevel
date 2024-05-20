using Microsoft.AspNetCore.Mvc;
using UserService.Models.Dto;

namespace UserService.Service.IService
{
    public interface ITitleService
    {
        Task<ResponseDto?> CreateTitle([FromBody] TitleDto model);
        Task<ResponseDto?> EditTitle([FromBody] TitleDto model);

        Task<ResponseDto?> DeleteTitle(int titleID);
    }
}
