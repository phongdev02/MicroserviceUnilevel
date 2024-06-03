using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using UserService.Context;
using UserService.Models;
using UserService.Models.Dto;
using UserService.Service.IService;
using UserService.Service.SetFunc;

namespace UserService.Service
{
    public class AuthService : IAuthService
    {
        private ResponseDto _responseDto;
        private readonly AppDBContext _context;
        private IMapper _mapper;
        private IJwtTokenGeneratetor _token;
        private SendGmailService _sendGmailService;
        private IHttpContextAccessor _contextAccessor;
        private readonly IUrlHelper _urlHelper;
        public AuthService(AppDBContext context,IMapper mapper, IJwtTokenGeneratetor token, IActionContextAccessor actionContextAccessor, IUrlHelperFactory urlHelperFactory, SendGmailService sendGmailService) { 
            _responseDto = new ResponseDto();
            _context = context;
        }

        public async Task<ResponseDto?> LogginAccountAsync([FromBody] LoginDto login)
        {
            try
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(nv => nv.email.ToLower().Trim().Equals(login.gmail.ToLower().Trim()));
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
                    if (!PasswordManager.VerifyPassword(login.passwork, account.Password))
                        return _responseDto = new ResponseDto()
                        {
                            Message = "password failt",
                            IsSuccess = true
                        };

                    //set token
                    List<string> roles = new List<string>();
                    roles.Add("admin");

                    var tam = _token.GenerateToken(_mapper.Map<AccountDto>(account), roles);

                    _responseDto = new ResponseDto()
                    {
                        Result = tam,
                        Message = "Login success",
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


        public async Task<ResponseDto?> ReadTokenAsync(string token)
        {
            try
            {
                var result = await _token.ReadToken(token);

                if (result == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "failt",
                    };
                }


                return _responseDto = new()
                {
                    Result = result,
                    Message = "Success",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error: " + ex.Message,
                };
            }
        }


        public async Task<ResponseDto?> SendEmailActiveAsync([FromBody]MailContextDto mailContextDto)
        {
            try
            {
                var result = await _token.ReadToken(mailContextDto.token);

                if (result == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "Token null",
                    };
                }

                string gmailAccess = Convert.ToString(result.email);

                var message = $"<p>Please confirm your account by <a style='color: blue', href='{mailContextDto.confirmationLink}'>clicking here</a>.</p>";

                // Ensure _sendGmailService is not null before using it
                if (_sendGmailService == null)
                {
                    throw new InvalidOperationException("SendGmailService is not initialized.");
                }

                await _sendGmailService.SendMail(new MailContent(gmailAccess, "Confirm your email", message));

                return _responseDto = new()
                {
                    Result = result,
                    Message = "Success",
                };

            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error: " + ex.Message,
                };
            }
        }

    }
}
