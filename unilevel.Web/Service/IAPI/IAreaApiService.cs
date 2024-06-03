using unilevel.Web.Models;

namespace unilevel.Web.Service.IAPI
{
    public interface IAreaApiService
    {
        Task<ResponseDto> GetAreasAsync();
        Task<ResponseDto> GetAreaAsync(string areacode);
        Task<ResponseDto> AddAreaAsync(AreaDto model);
        Task<ResponseDto> DeleteAreaAsync(string areacode);
        Task<ResponseDto> FindAreaAsync(string inputSearch);
        Task<ResponseDto> EditAreaAsync(AreaDto model);
    }
}
