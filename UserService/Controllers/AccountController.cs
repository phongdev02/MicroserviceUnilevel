using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using UserService.Models.Dto;
using UserService.Service;
using UserService.Service.IService;

namespace UserService.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ResponseDto _responseDto;
        private IAccountService _accountService;
        private readonly SendGmailService _sendGmailService;
        public AccountController(IAccountService accountService, SendGmailService sendGmailService) {
            _responseDto = new ResponseDto();
            _accountService = accountService;
            _sendGmailService = sendGmailService;
        }

        [HttpPost]
        public async Task<ResponseDto> CreateAccount([FromBody] AccountDtoNoID model, int? managementID)
        {
            try
            {
                var check = await _accountService.CreateAccount(model, managementID);

                if (check != null && check.IsSuccess == true) {
                    return check;
                }

                return check;
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    Result = false,
                    Message = ex.Message
                };
            }
        }

        [HttpGet]
        public async Task<ResponseDto> AccountSearch(String search)
        {
            try
            {
                var check = await _accountService.AccountSearch(search);

                if (check != null && check.IsSuccess == true)
                {
                    return check;
                }

                return check;
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    Result = false,
                    Message = ex.Message
                };
            }
        }

        [HttpGet("LogginAccount")]
        public async Task<ResponseDto> LogginAccount(string gmail, string pass)
        {
            try
            {
                var check = await _accountService.LogginAccount(gmail, pass);

                if (check != null && check.IsSuccess == true)
                {
                    return check;
                }

                return check;
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    Result = false,
                    Message = ex.Message
                };
            }
        }

        [HttpGet("SendGmail")]
        public async Task<ResponseDto?> SendGmail(string noidung)
        {
            try
            {
                var check = await MailUtils.SendMail("unilevelphong@gmail.com", "n.v.p200200@gmail.com", "test send email", noidung);

                return _responseDto = new()
                {
                    Result = check,
                };
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    Result = false,
                    Message = ex.Message
                };
            }
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] MailContent mailContent)
        {
            var result = await _sendGmailService.SendMail(mailContent);
            if (result.Contains("Error"))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
