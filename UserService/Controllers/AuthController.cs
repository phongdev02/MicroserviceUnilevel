using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using UserService.Models.Dto;
using UserService.Service.IService;

namespace UserService.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _authService;
        public ResponseDto _responseDto;
        public AuthController(IAuthService authService) { 
            _authService = authService;
            _responseDto = new ResponseDto();
        }

        [HttpPost("LogginAccount")]
        public async Task<IActionResult> LogginAccount([FromBody]LoginDto login)
        {
            var responseDto = await _authService.LogginAccountAsync(login);

            if (responseDto == null || responseDto.IsSuccess == false)
            {
                return BadRequest(responseDto);
            }
            else return Ok(responseDto);
        }

        [HttpGet("ReadToken/{token}")]
        public async Task<IActionResult> ReadToken(string token)
        {
            var responseDto = await _authService.ReadTokenAsync(token);

            if (responseDto == null || responseDto.IsSuccess == false)
            {
                return BadRequest(responseDto);
            }
            else return Ok(responseDto);
        }

        [HttpPost("SendEmailActive")]
        public async Task<IActionResult> SendEmailActive([FromBody]MailContextDto mailContextDto)
        {
            var responseDto = await _authService.SendEmailActiveAsync(mailContextDto);

            if (responseDto == null || responseDto.IsSuccess == false)
            {
                return BadRequest(responseDto);
            }
            else return Ok(responseDto);
        }

    }
}
