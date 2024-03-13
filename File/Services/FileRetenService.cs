using FileRetention.Context;
using FileRetention.Models;
using FileRetention.Models.Dto;
using FileRetention.Services.IServices;
using Microsoft.Data.SqlClient;
using System.IO;

namespace FileRetention.Services
{
    public class FileRetenService : IFileRetenService
    {
        private readonly AppDBContext _db;
        public ResponseDto _responseDto;
        private long sizeMax = Int32.MaxValue; // Maximum = 2GB
        public FileRetenService(AppDBContext db)
        {
            _db = db;
            _responseDto = new ResponseDto();
        }
        public async Task<ResponseDto> AddFileAsync(string filePath)
        {
            Tep tep = new Tep();

            try
            {
                var file = await GetFileByte(filePath);
                if (file == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "File error or over max size",
                        Result = null
                    };
                }
                else
                {
                    tep.KieuTep = await GetFileExtension(filePath);
                    tep.DuLieu = file;
                    tep.NgayTao = DateTime.Now;
                    tep.TenTep = await GetFileName(filePath);
                    tep.TrangThai = true;

                    _db.Teps.Add(tep);
                    await _db.SaveChangesAsync();
                    return _responseDto = new()
                    {
                        IsSuccess = true,
                        Message = "File " + tep.TenTep + " đang được tạo",
                        Result = tep
                    };
                }
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error: " + ex.ToString(),
                    Result = null
                };
            }

            return _responseDto;
        }

        public Task<ResponseDto> EditFileAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> GetFileAsync()
        {
            try
            {
                var lsFile = _db.Teps.ToList();

                return _responseDto = new()
                {
                    IsSuccess = true,
                    Message = "get list tep on db",
                    Result = lsFile
                };
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error: " + ex.ToString(),
                    Result = null
                };
            }
        }

        private async Task<byte[]> GetFileByte(string filePath)
        {
            try
            {
                var sizeFile = new FileInfo(filePath).Length;
                // kiem tra file 
                if (sizeFile > sizeMax)
                {
                    return null;
                }
                else
                {
                    byte[] fileBytes;
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        fileBytes = new byte[fs.Length];
                        fs.Read(fileBytes, 0, (int)fs.Length);
                    }
                    return fileBytes;
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần thiết
                return null;
            }
        }

        private async Task<string> GetFileExtension(string filePath)
        {
            return Path.GetExtension(filePath)?.TrimStart('.');
        }

        private async Task<string> GetFileName(string filePath)
        {
            try
            {
                return Path.GetFileName(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}
