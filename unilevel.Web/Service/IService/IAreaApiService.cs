using unilevel.Web.Models;

namespace unilevel.Web.Service.IService
{
    public interface IAreaApiService
    {
        Task<ResponseDto?> GetAreas();
        Task<ResponseDto?> GetArea(string khuvucID);
        Task<ResponseDto?> AddArea(KhuvucDto model);
        Task<ResponseDto?> DeleteArea(string KhuvucID);
        Task<ResponseDto?> FindArea(string inputSearch);
        Task<ResponseDto?> EditArea(KhuvucDto model);
    }
}
