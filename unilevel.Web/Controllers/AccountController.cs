using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using unilevel.Web.Models;
using unilevel.Web.Service.API;
using unilevel.Web.Service.IAPI;
using unilevel.Web.Service.IService;

namespace unilevel.Web.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ResponseDto _responseDto;
        private IAccountAPIService _accountService;
        private IAccountService _account;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ITokenProvider _cookie;

        public AccountController(IAccountService account, IAccountAPIService accountService, IHttpContextAccessor contextAccessor, ITokenProvider cookie)
        {
            _responseDto = new ResponseDto();
            _accountService = accountService;
            _contextAccessor = contextAccessor;
            _cookie = cookie;
            _account = account;
        }

        [HttpPost("CreateAccountAsync")]
        public async Task<IActionResult> CreateAccountAsync([FromBody] AccountDtoNoID model)
        {
            var check = await _accountService.CreateAccountAsync(model);

            if (check != null && check.IsSuccess == true)
            {
                return Ok(check);
            }

            return BadRequest(check);
        }

        [HttpGet("AccountSearchAsync/{search}")]
        public async Task<IActionResult> AccountSearchAsync(String search)
        {
            var check = await _accountService.AccountSearchAsync(search);

            if (check != null && check.IsSuccess == true)
            {
                return Ok(check);
            }


            return BadRequest(check);
        }

        [HttpPost("LogginAccountAsync")]
        public async Task<IActionResult> LogginAccountAsync(LoginDto model)
        {
            var responsedto = await _accountService.LogginAccountAsync(model);

            if (responsedto != null && responsedto.IsSuccess == true)
            {
                var request = HttpContext.Request;
                var mailcontextdto = new MailContextDto();
                mailcontextdto.token = Convert.ToString(responsedto.Result);
                var result = await _accountService.SendEmailAsync(mailcontextdto, request);

                if (result != null || result.IsSuccess == false)
                {
                    return BadRequest(result);
                }
            }
            return Ok(responsedto);
        }

        [HttpGet("SetCookie/{token}")]
        public async Task<IActionResult> SetCookie(string token)
        {
            var responseDto = await _accountService.ReadTokenAsync(token);

            _cookie.setToken(token);
            return Ok("Succes");

/*            if (responseDto != null && responseDto.IsSuccess == true)
            {
                
            }
            */
            //return BadRequest("Fail access");
            
        }
    }
}
