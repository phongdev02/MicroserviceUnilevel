using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style.XmlAccess;
using UserService.Models.Dto;
using UserService.Context;
using UserService.Service.IService;
using UserService.Models;
using UserService.Service.SetFunc;

namespace UserService.Service
{
    public class TaikhoanService : ITaikhoanService
    {
        private readonly AppDBContext _context;
        private ResponseDto _responseDto;
        private PasswordManager _passwordManager;
        private IMapper _mapper;

        public TaikhoanService(AppDBContext dBContext, IMapper mapper)
        {
            _context = dBContext;
            _responseDto = new ResponseDto();
            _passwordManager = new PasswordManager();
            _mapper = mapper;
        }

        public async Task<ResponseDto> GetListNhanVat()
        {
            try
            {
                var models = await _context.Nhanviens.ToListAsync();

                if (models.Count <= 0)
                {
                    return _responseDto = new ResponseDto()
                    {
                        Result = null,
                        Message = "Không có nhân viên nào",
                        IsSuccess = false
                    };
                }
                else
                {
                    return _responseDto = new ResponseDto()
                    {
                        Result = models,
                        Message = "Day la danh sach nhan vien sau",
                        IsSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                return _responseDto = new ResponseDto()
                {
                    Result = null,
                    Message = "Loi: " + ex.ToString(),
                    IsSuccess = false
                };
                throw;
            }
        }

        public async Task<ResponseDto> CreateAccount([FromBody] NhanvienDtoNoID nhanvienDto)
        {
            try
            {
                // Tạo một đối tượng nhân viên mới từ dữ liệu nhận được
                var obj = _mapper.Map<Nhanvien>(nhanvienDto);

                obj.GmailDangnhap = nhanvienDto.GmailNv;
                obj.GmailNv = nhanvienDto.GmailNv;

                //create random account
                var pass = _passwordManager.GeneratePassword(12);

                var hasher = new PasswordHasher<string>();
                var hashedPassword = hasher.HashPassword(null, pass);

                obj.MatkhauNv = hashedPassword;

                // Thêm nhân viên mới vào cơ sở dữ liệu
                _context.Nhanviens.Add(obj);
                _context.SaveChanges();

                _responseDto.Result = _mapper.Map<NhanvienDto>(obj);

                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        public async Task<ResponseDto> EditAccount([FromBody] NhanvienDtoNoID nhanvienDtoNoID)
        {
            try
            {
                // Tạo một đối tượng nhân viên mới từ dữ liệu nhận được
                var obj = _mapper.Map<Nhanvien>(nhanvienDtoNoID);

                var pass = _passwordManager.GeneratePassword(12);

                var hasher = new PasswordHasher<string>();
                var hashedPassword = hasher.HashPassword(null, pass);

                obj.MatkhauNv = hashedPassword;

                // Thêm nhân viên mới vào cơ sở dữ liệu
                _context.Nhanviens.Add(obj);
                _context.SaveChanges();

                _responseDto.Result = _mapper.Map<NhanvienDto>(obj);

                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        public async Task<ResponseDto> EditPass(int id, string passOld, string passNew)
        {
            try
            {
                var taikhoan = await _context.Nhanviens.FirstOrDefaultAsync(nv => nv.NvId == id);
                if (taikhoan == null || passOld.Equals(passNew))
                {
                    _responseDto = new ResponseDto()
                    {
                        Message = "Mat khau khong trung khop",
                        IsSuccess = false
                    };
                }
                _responseDto.Result = taikhoan;
            }
            catch (Exception ex)
            {
                _responseDto = new ResponseDto()
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
                throw;
            }
            return _responseDto;
        }

        public async Task<ResponseDto> LogginAccount(string gmail, string pass)
        {
            try
            {
                var taikhoan = await _context.Nhanviens.FirstOrDefaultAsync(nv => nv.GmailNv.ToLower() == gmail.ToLower() && _passwordManager.VerifyPassword(pass, nv.MatkhauNv));
                if (taikhoan == null)
                {
                    _responseDto = new ResponseDto()
                    {
                        Message = "Tên đăng nhập/gmail hoặc mật khẩu không đúng",
                        IsSuccess = false
                    };
                }
                _responseDto.Result = taikhoan;

            }
            catch (Exception ex)
            {
                _responseDto = new ResponseDto()
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
                throw;
            }
            return _responseDto;
        }

        public async Task<ResponseDto> StatusAccount(int id)
        {
            try
            {
                var taikhoan = await _context.Nhanviens.FirstOrDefaultAsync(nv => nv.NvId == id);
                if (taikhoan == null)
                {
                    _responseDto = new ResponseDto()
                    {
                        Message = "Không có nhân viên nào",
                        IsSuccess = false
                    };
                }
                if (taikhoan.TrangthaiNv == true)
                {
                    taikhoan.TrangthaiNv = false;
                    _context.Nhanviens.Update(taikhoan);
                    _context.SaveChanges();
                }
                else
                {
                    taikhoan.TrangthaiNv = true;
                    _context.Nhanviens.Update(taikhoan);
                    _context.SaveChanges();
                }
                _responseDto.Result = taikhoan;
            }
            catch (Exception ex)
            {
                _responseDto = new ResponseDto()
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
                throw;
            }
            return _responseDto;
        }

        public Task<ResponseDto> findNameOrGmail(string textInput)
        {
            throw new NotImplementedException();
        }
    }
}
