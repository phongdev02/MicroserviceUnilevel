using FileRetention.Models.Dto;

namespace FileRetention.Services.IServices
{
    public interface IFileRetenService
    {
        Task<ResponseDto> AddFileAsync(IFormFile filePath);
        Task<ResponseDto> GetFileAsync();
        Task<ResponseDto> EditFileAsync(int id, IFormFile filePath);
        Task<ResponseDto> DownloadFile(int tepId);
    }
}
