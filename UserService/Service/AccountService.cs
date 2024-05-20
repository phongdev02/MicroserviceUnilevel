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
using System.Net.Mail;

namespace UserService.Service
{
    public class AccountService : IAccountService
    {
        private readonly AppDBContext _context;
        private ResponseDto _responseDto;
        private PasswordManager _passwordManager;
        private IMapper _mapper;
        private IJwtTokenGeneratetor _token;

        public AccountService(AppDBContext dBContext, IMapper mapper, IJwtTokenGeneratetor token)
        {
            _context = dBContext;
            _responseDto = new ResponseDto();
            _passwordManager = new PasswordManager();
            _mapper = mapper;
            _token = token;
        }

        public async Task<ResponseDto?> LogginAccount(string gmail, string pass)
        {
            try
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(nv => nv.email.ToLower().Trim().Equals(gmail.ToLower().Trim()));
                if (account == null)
                {
                    _responseDto = new ResponseDto()
                    {
                        Message = "Tên đăng nhập/gmail hoặc mật khẩu không đúng",
                        IsSuccess = false
                    };
                }
                else
                {
                    if (!PasswordManager.VerifyPassword(pass, account.Password))
                        return _responseDto = new ResponseDto()
                        {
                            Message = "password failt",
                            IsSuccess = true
                        };

                    var tam = _token.GenerateToken(_mapper.Map<AccountDto>(account), "admin");

                    _responseDto = new ResponseDto()
                    {
                        Message = tam,
                        IsSuccess = true
                    };
                }
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
                var taikhoan = await _context.Accounts.FirstOrDefaultAsync(nv => nv.accId == id);
                if (taikhoan == null)
                {
                    _responseDto = new ResponseDto()
                    {
                        Message = "Không có nhân viên nào",
                        IsSuccess = false
                    };
                }
                if (taikhoan.status == true)
                {
                    taikhoan.status = false;
                    _context.Accounts.Update(taikhoan);
                    _context.SaveChanges();
                }
                else
                {
                    taikhoan.status = true;
                    _context.Accounts.Update(taikhoan);
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

        public bool IsValidEmail(string email)
        {
            try
            {
                // Khởi tạo đối tượng MailAddress
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public async Task<ResponseDto?> CreateAccount([FromBody] AccountDtoNoID model, int? managementID)
        {
            try
            {
                // Tạo một đối tượng nhân viên mới từ dữ liệu nhận được
                var obj = _mapper.Map<Account>(model);

                if (IsValidEmail(model.email) == false)
                    return _responseDto = new ResponseDto()
                    {
                        IsSuccess = false,
                        Result = null,
                        Message = "try again"
                    };

                obj.email = model.email;

                // kiểm tra người quản lý của người dùng trên
                if (managementID != null && managementID != 0) obj.managerID = managementID;
                else obj.managerID = null;

                // kiểm tra khu vực khi thêm người dùng
                if (!_context.Areas.Any(item => item.areaCode.ToLower().Trim().Equals(model.areaCode.Trim().ToLower()))) obj.areaCode = null;

                //create random account
                var pass = _passwordManager.GeneratePassword(12);

                var hashedPassword = _passwordManager.HashPassword(pass);

                obj.Password = hashedPassword;
                //obj.Password = pass;


                // Thêm nhân viên mới vào cơ sở dữ liệu
                _context.Accounts.Add(obj);
                _context.SaveChanges();

                _responseDto.Result = _mapper.Map<AccountDto>(obj);

                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;

                return _responseDto;
            }
        }

        public async Task<ResponseDto?> AccountSearch(String search)
        {
            try
            {
                var lsaccount = _context.Accounts.Include(x => x.area);

                var models = lsaccount.Where(item => item.fullName.ToLower().Trim().Contains(search.ToLower().Trim())
                                                                || item.email.ToLower().Trim().Contains(search.ToLower().Trim())
                                                                || item.area.areaName.ToLower().Trim().Contains(search.ToLower().Trim())).ToList();

                if (models.Count == 0)
                {
                    return new ResponseDto()
                    {
                        IsSuccess = false,
                        Result = null,
                        Message = "no account"

                    };
                }


                return new ResponseDto()
                {
                    IsSuccess = true,
                    Result = models,

                };
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;

                return _responseDto;
            }
        }
    }
}
