using UserService.Models.Dto;

namespace UserService.Service.IService
{
    public interface IViengThamService
    {
        Task<ResponseDto?> getLsViengTham();
        Task<ResponseDto?> getViengTham(int id);
        Task<ResponseDto?> CreateViengTham(ViengThamDto viengTham);
        Task<ResponseDto?> UpdateViengTham(ViengThamDto viengTham);
        Task<ResponseDto?> DeleteViengTham(int id);
    }
}
