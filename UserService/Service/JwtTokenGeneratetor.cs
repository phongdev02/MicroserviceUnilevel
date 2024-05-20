using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.Models;
using UserService.Models.Dto;
using UserService.Service.IService;

namespace UserService.Service
{
    public class JwtTokenGeneratetor : IJwtTokenGeneratetor
    {
        private readonly JwtOptions _JwtOptions;

        public JwtTokenGeneratetor(IOptions<JwtOptions> JwtOptions)
        {
            _JwtOptions = JwtOptions.Value;
        }

        public string GenerateToken(AccountDto applicationUser, string roles)
        {
            //craete element JwtSecurityTokenHandler is a class on namespace
            //use: create, Authentication or Process JWT (JSON Web Tokens) 
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_JwtOptions.Secret);

            var claimList = new List<Claim>
            {
                new Claim("accId", applicationUser.accId.ToString()),
                new Claim("email",applicationUser.email),
                new Claim("titleID",applicationUser.titleID.ToString()),
                new Claim("fullName",applicationUser.fullName),
                new Claim("role", roles)
            };

            //claimList.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptions = new SecurityTokenDescriptor()
            {
                Audience = _JwtOptions.Audience,
                Issuer = _JwtOptions.Issuer,
                //data token
                Subject = new ClaimsIdentity(claimList),
                //time of existencex
                Expires = DateTime.UtcNow.AddDays(7),
                //create SymmetricSecurityKey with key and algorithm(thuật toán) 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptions);

            return tokenHandler.WriteToken(token);
        }
    }
}
