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
using System.Security.Claims;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Options;
using static System.Net.WebRequestMethods;
using System.Net.WebSockets;

namespace UserService.Service
{
    public class AccountService : IAccountService
    {
        private readonly AppDBContext _context;
        private ResponseDto _responseDto;
        private PasswordManager _passwordManager;
        private readonly IMapper _mapper;
        
        public AccountService(AppDBContext dBContext, IMapper mapper)
        {
            _context = dBContext;
            _responseDto = new ResponseDto();
            _passwordManager = new PasswordManager();
            _mapper = mapper;
        }

       
        public async Task<ResponseDto> StatusAccountAsync(int id)
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

        private bool IsValidEmail(string email)
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

        public async Task<ResponseDto?> CreateAccountAsync([FromBody] AccountDtoNoID model)
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
                if (model.managerID != null && model.managerID != 0) obj.managerID = model.managerID;
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

        public async Task<ResponseDto?> AccountSearchAsync(String search)
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
                    Result =_mapper.Map<List<AccountDto>>(models),

                };
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;

                return _responseDto;
            }
        }

        
        public async Task<ResponseDto?> EditAccountAsync([FromBody] AccountDtoNoID model)
        {
            try
            {
                // Tạo một đối tượng nhân viên mới từ dữ liệu nhận được
                var obj = _mapper.Map<Account>(model);

                var accout = await _context.Accounts.AnyAsync(acc => acc.accId == obj.accId);

                if(!accout || !IsValidEmail(model.email))
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "No Availalbe"
                    };
                }
                else
                {
                    // kiểm tra người quản lý của người dùng trên
                    if (model.managerID != null && model.managerID != 0) obj.managerID = model.managerID;
                    else obj.managerID = null;

                    var hashedPassword = _passwordManager.HashPassword(obj.Password);

                    obj.Password = hashedPassword;

                    _context.Accounts.Update(obj);
                    _context.SaveChanges();

                    return _responseDto = new(){
                        Result = _mapper.Map<AccountDto>(obj),
                        Message = "Edit succes"
                    };
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;

                return _responseDto;
            }
        }

        public async Task<ResponseDto?> GetLsAccountAsync()
        {
            try
            {
                // Tạo một đối tượng nhân viên mới từ dữ liệu nhận được
                var lsAccount = _context.Accounts.ToList();

                if (lsAccount.Count == 0)
                {
                    return _responseDto = new()
                    {
                        Message = "No account"
                    };
                }
                else
                {
                    var result = _mapper.Map<List<AccountDto>>(lsAccount);

                    return _responseDto = new()
                    {
                        Result = result,
                        Message = "Find success"
                    };
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;

                return _responseDto;
            }
        }

        public async Task<ResponseDto?> GetAccountAsync(int accid)
        {
            try
            {
                // Tạo một đối tượng nhân viên mới từ dữ liệu nhận được
                var account = await _context.Accounts.FirstOrDefaultAsync(acc => acc.accId == accid);

                if (account == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "No Availalbe"
                    };
                }
                else
                {
                    var result = _mapper.Map<AccountDto>(account);

                    return _responseDto = new()
                    {
                        Result = result,
                        Message = "Find success"
                    };
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;

                return _responseDto;
            }
        }

        public async Task<ResponseDto?> DeleteAccountAsync(int accid)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(acc => acc.accId == accid);

            try
            {
                // Tạo một đối tượng nhân viên mới từ dữ liệu nhận được

                if (account == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "No Availalbe"
                    };
                }
                else
                {
                    var result = _mapper.Map<AccountDto>(account);

                    return _responseDto = new()
                    {
                        Result = result,
                        Message = "Delete success"
                    };
                }
            }
            catch (Exception ex)
            {
                var response = await StatusAccountAsync(accid);
                if(response == null || response.IsSuccess == false)
                    return _responseDto = new() { Message = ex.Message };

                return _responseDto = new()
                {
                    Result = _mapper.Map<AccountDto>(account),
                    Message = "Delete success"
                };
            }
        }
    }
}
