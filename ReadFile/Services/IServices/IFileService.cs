using ReadFile.Models.Dto;

namespace ReadFile.Services.IServices
{
    public interface IFileService
    {
        // if typeFile == true => return file Excle
        // if typeFile == false => return file CSV
        Task<FileDto> DownloadFileNV(TypeFileDto.typeFile typeFile);
        Task<ResponseDto> ReadFileExcelNV(string filePath);
        Task<ResponseDto> ReadFileCSVNV(string filePath);
    }
}
