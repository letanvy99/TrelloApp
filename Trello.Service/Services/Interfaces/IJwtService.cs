using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Trello.Service.Services.Interfaces
{
    public interface IJwtService
    {
        Task<string> BuildToken(string identifier, int expiredTimeInMinutes);

        Task<string> BuildToken(Claim[] claims, int expiredTimeInMinutes);

        Task<bool> ValidateToken(string token);

        Task<JwtSecurityToken> DecodeToken(string tokenString);
    }
}
