using FileRetention.Models.Dto;

namespace FileRetention.Services.IServices
{
    public interface IFileRetenService
    {
        Task<ResponseDto> AddFileAsync(string filePath);
        Task<ResponseDto> GetFileAsync();
        Task<ResponseDto> EditFileAsync(string filePath);
    }
}
