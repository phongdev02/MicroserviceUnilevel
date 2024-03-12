using AuthAPI.Context;
using AuthAPI.Models.Dto;
using AuthAPI.Models;
using AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDBContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGeneratetor _jwtTokenGeneratetor;

        public AuthService(AppDBContext db, UserManager<ApplicationUser> userManager, IJwtTokenGeneratetor jwtTokenGeneratetor, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGeneratetor = jwtTokenGeneratetor;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = await _db.ApplicationUsers.SingleOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            if (user == null)
            {
                return false; // Không tìm thấy người dùng
            }

            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                // Nếu vai trò không tồn tại, tạo mới
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // Kiểm tra xem người dùng đã có vai trò này chưa
            if (!await _userManager.IsInRoleAsync(user, roleName))
            {
                // Nếu chưa, thêm người dùng vào vai trò
                await _userManager.AddToRoleAsync(user, roleName);
            }

            return true; // Thêm vai trò thành công
        }


        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(user => user.UserName.ToLower() == loginRequestDto.UserName.ToLower());
            var isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (!isValid || user == null)
            {
                return new LoginResponseDto() { User = null, Token = "" };
            }
            // if user was found, genegrate JWT token
            var role = await _userManager.GetRolesAsync(user);

            var token = _jwtTokenGeneratetor.GenerateToken(user, role);

            UserDto userDto = new()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Phone = user.PhoneNumber
            };

            LoginResponseDto _loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = token
            };

            return _loginResponseDto;
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new(){ 
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email,
                Name = registrationRequestDto.Name,
                PhoneNumber = registrationRequestDto.Phone
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);

                if(result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(user => user.UserName == registrationRequestDto.Email);
                    UserDto userDto = new()
                    {
                        Email = userToReturn.Email,
                        Id = userToReturn.Id,
                        Name = userToReturn.Name,
                        Phone = userToReturn.PhoneNumber
                    };
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
                throw;
            }
        }
    }
}
