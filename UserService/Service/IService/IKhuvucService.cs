using UserService.Models;
using UserService.Models.Dto;

namespace UserService.Service.IService
{
    public interface IKhuvucService
    {
        Task<ResponseDto> GetAreas();
        Task<ResponseDto> GetArea(string khuvucID);
        Task<ResponseDto> AddArea(KhuvucDto model);
        Task<ResponseDto> DeleteArea(string KhuvucID);
        Task<ResponseDto> FindArea(string inputSearch);
        Task<ResponseDto> EditArea(KhuvucDto model);
    }
}
