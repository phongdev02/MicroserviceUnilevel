using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TaiKhoan.Models.Dto;
using unilevel.Web.Models;
using unilevel.Web.Service;
using unilevel.Web.Service.IService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Azure;

namespace unilevel.Web.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ResponseDto _responDto;
        private readonly ITokenProvider _tokenProvider;
        public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _responDto = new ResponseDto();
            _tokenProvider = tokenProvider;
         }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {

            ResponseDto? response = await _authService.LoginAsync(model);

            if (response != null && response.IsSuccess == true)
            {
                LoginResponseDto lst = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(response.Result));

                await signInUser(lst);

                _tokenProvider.setToken(lst.Token);
                
                _responDto.Result = lst;
            }

            return Ok(_responDto);
        }

        [HttpGet("Logout")]
        public async Task<OkResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.clearToken();
            return Ok();
        }

        [HttpGet("LoginWithToken")]
        public async Task<IActionResult> LoginWithToken()
        {
            var cookie = _tokenProvider.getToken();

            //convert cookie to jwt token with authorization

            JwtSecurityToken token = new JwtSecurityToken(cookie);

            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto  model)
        {

            ResponseDto? response = await _authService.RegisterAsync(model);

            return Ok(response);
        }

        private async Task signInUser(LoginResponseDto model)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(model.Token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, 
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));

            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));

            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));

            identity.AddClaim(new Claim(ClaimTypes.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));

            var principer = new ClaimsPrincipal(identity);


            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principer);
        }
    }
}
