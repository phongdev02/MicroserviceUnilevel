using unilevel.Web.Models;

namespace unilevel.Web.Service.IService
{
    public interface IAreaService
    {
        Task<ResponseDto?> GetAreasAsync();
        Task<ResponseDto?> GetAreaAsync(string areacode);
        Task<ResponseDto?> AddAreaAsync(AreaDto model);
        Task<ResponseDto?> DeleteAreaAsync(string areacode);
        Task<ResponseDto?> FindAreaAsync(string inputSearch);
        Task<ResponseDto?> EditAreaAsync(AreaDto model);
    }
}
