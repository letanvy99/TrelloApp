using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Trello.Service.Services.Interfaces;

namespace Trello.Service.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        private readonly string _issuer;

        private readonly string _key;

        private readonly string _audience;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = _configuration["Jwt:Key"];
            _issuer = _configuration["Jwt:Issuer"];
            _audience = _configuration["Jwt:Audience"];
        }

        public Task<string> BuildToken(string identifier, int expiredTimeInMinutes)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,identifier)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new JwtSecurityToken(_issuer, _audience, claims,
                expires: DateTime.Now.AddMinutes(expiredTimeInMinutes), signingCredentials: credentials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(tokenDescriptor));
        }

        public Task<string> BuildToken(Claim[] claims, int expiredTimeInMinutes)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new JwtSecurityToken(_issuer, _audience, claims,
                expires: DateTime.Now.AddMinutes(expiredTimeInMinutes), signingCredentials: credentials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(tokenDescriptor));
        }

        public Task<bool> ValidateToken(string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(_key);

            var mySecurityKey = new SymmetricSecurityKey(mySecret);

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<JwtSecurityToken> DecodeToken(string tokenString)
        {
            var handler = new JwtSecurityTokenHandler();

            var token = handler.ReadToken(tokenString) as JwtSecurityToken;

            return Task.FromResult(token);
        }
    }
}
