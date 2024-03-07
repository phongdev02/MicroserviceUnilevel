using AuthAPI.Models;
using AuthAPI.Service.IService;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthAPI.Service
{
    public class JwtTokenGeneratetor : IJwtTokenGeneratetor
    {
        private readonly JwtOptions _JwtOptions;
        public JwtTokenGeneratetor(IOptions<JwtOptions> JwtOptions)
        {
            _JwtOptions = JwtOptions.Value;
        }

        public string GenerateToken(ApplicationUser applicationUser)
        {
            //craete element JwtSecurityTokenHandler is a class on namespace
            //use: create, Authentication or Process JWT (JSON Web Tokens) 
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_JwtOptions.Secret);

            var claimList = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email,applicationUser.Email),
                new Claim(JwtRegisteredClaimNames.Sub,applicationUser.Id),
                new Claim(JwtRegisteredClaimNames.Name,applicationUser.UserName)
            };

            var tokenDescriptions = new SecurityTokenDescriptor()
            {
                Audience = _JwtOptions.Audience,
                Issuer = _JwtOptions.Issuer,
                //data token
                Subject = new ClaimsIdentity(claimList),
                //time of existencex
                Expires = DateTime.UtcNow.AddDays(7),
                //create SymmetricSecurityKey with key and algorithm(thuật toán) 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptions);

            return tokenHandler.WriteToken(token);
        }
    }
}
