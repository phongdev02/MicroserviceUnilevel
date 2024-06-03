using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
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

        public string GenerateToken(AccountDto applicationUser, List<string> roles)
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
            };

            claimList.AddRange(roles.Select(role => new Claim("roles", role)));

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

        public async Task<AccountDto> ReadToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Token cannot be null or empty", nameof(token));
            }

            var handler = new JwtSecurityTokenHandler();

            // Validate the token and read the claims
            if (handler.CanReadToken(token))
            {
                var jwtToken = handler.ReadJwtToken(token);
                var claims = jwtToken.Claims;

                var accId =int.Parse(claims.FirstOrDefault(c => c.Type == "accId")?.Value);
                var email = claims.FirstOrDefault(c => c.Type == "email")?.Value;
                var titleID = int.Parse(claims.FirstOrDefault(c => c.Type == "titleID")?.Value);
                var fullName = claims.FirstOrDefault(c => c.Type == "fullName")?.Value;
                List<string> roles = jwtToken.Claims
                .Where(c => c.Type == "roles")
                .Select(c => c.Value)
                .ToList();

                var accout = new AccountDto()
                {
                    accId = accId,
                    email = email,
                    titleID = titleID,
                    fullName = fullName
                };

                return accout;
            }
            else
            {
                throw new ArgumentException("Invalid token format", nameof(token));
            }
        }
    }
}
