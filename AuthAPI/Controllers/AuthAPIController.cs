using AuthAPI.Context;
using AuthAPI.Models.Dto;
using AuthAPI.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TaiKhoan.Models.Dto;

namespace AuthAPI.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _responseDto;
        private readonly AppDBContext _db;

        public AuthAPIController(IAuthService authService, AppDBContext db)
        {
            _authService = authService;
            _responseDto = new ResponseDto();
            _db = db;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage)) {
                _responseDto.IsSuccess = false;
                _responseDto.Message = errorMessage; 
                return BadRequest(_responseDto);
            }
            return Ok(_responseDto);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var loginResponseDto = await _authService.Login(loginRequestDto);
            //Object loginResponseDto = null;

            if (loginResponseDto == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "User or password is incorrect";
                return BadRequest(_responseDto);
            }
            _responseDto.Result = loginResponseDto;
            return Ok(_responseDto);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var loginResponseDto = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            //Object loginResponseDto = null;

            if (!loginResponseDto)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "no user of no available";
                return BadRequest(_responseDto);
            }
            return Ok(_responseDto);
        }
    }
}
