using FileRetention.Context;
using FileRetention.Models;
using FileRetention.Models.Dto;
using FileRetention.Services.IServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ResponseDto> AddFileAsync(IFormFile filePath)
        {
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
                    var tep = new Tep();

                    tep.KieuTep = await GetFileExtension(filePath.FileName);
                    tep.DuLieu = file;
                    tep.contentType = filePath.ContentType;
                    tep.TenTep = filePath.FileName;

                    tep.TrangThai = true;

                    await _db.Teps.AddAsync(tep);
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
        }

        public async Task<ResponseDto> DownloadFile(int tepId)
        {
            try
            {
                var tep = _db.Teps.FirstOrDefault(item => item.TepId == tepId);

                if (tep == null)
                {
                    _responseDto = new ResponseDto()
                    {
                        Result = null,
                        Message = "Tep not found",
                        IsSuccess = false
                    };
                    return _responseDto;
                }
                else
                {
                    return new ResponseDto()
                    {
                        IsSuccess = true,
                        Message = "File " + tep.TenTep + " có tồn tại",
                        Result = tep
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto()
                {
                    Result = null,
                    Message = "Tep not found",
                    IsSuccess = false
                };
            }
        }

        public async Task<ResponseDto> EditFileAsync(int id, IFormFile filePath)
        {
            try
            {
                Tep tep = await _db.Teps.FirstOrDefaultAsync(item => item.TepId == id);

                var file = await GetFileByte(filePath);

                if (tep == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "No file or file over limit size, edit and try again",
                        Result = null
                    };
                }
                else
                {
                    //save tep cu vao table TepCu trong DB
                    TepCu tepCu = new TepCu
                    {
                        TenTep = tep.TenTep,
                        NgayChinhXua = DateTime.Now,
                        Kieutep = tep.KieuTep,
                        contentType = tep.contentType,
                        Dulieu = tep.DuLieu,
                        TacDong = "Update",
                        TrangThai = true,
                        TepID = tep.TepId
                    };
                    await _db.TepCus.AddAsync(tepCu);
                    await _db.SaveChangesAsync();

                    //update tep on table tep on DB
                    tep.KieuTep = await GetFileExtension(filePath.FileName); 
                    tep.DuLieu = file;
                    tep.contentType = filePath.ContentType;
                    tep.TenTep = filePath.FileName;
                    tep.TrangThai = true;

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

        private async Task<byte[]> GetFileByte(IFormFile file)
        {
            try
            {
                // kiem tra file 
                if (file == null || file.Length == 0)
                {
                    return null;
                }

                // Đọc nội dung của tệp và lưu vào một MemoryStream
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();
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
    }
}
