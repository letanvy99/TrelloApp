using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Trello.Service.Constants;
using Trello.Service.Enums;
using Trello.Service.Models.Error;
using Trello.Service.Models.Users.Request;
using Trello.Service.Models.Users.Response;
using Trello.Service.Services.Interfaces;

namespace Trello.API.Controllers
{
    [Route("auth")]
    public class AuthController : BaseController
    {
        private const int TOKEN_EXPIRED_TIME = 1440;

        private const int REFRESH_TOKEN_EXPIRED_TIME = 10080;

        private IJwtService _jwtService;

        private IUserService _userService;

        public AuthController(IJwtService jwtService, IUserService userService)
        {
            _jwtService = jwtService;

            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserTokenLogin>> Login([FromBody] UserLogin request)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.CheckUserLogin(request);

                if (user != null)
                {
                    var claims = new[]
                    {
                            new Claim(ClaimTypes.NameIdentifier,user.UserName),
                            new Claim(CustomizeClaimType.UserId, user.Id.ToString())
                        };

                    var token = await _jwtService.BuildToken(claims, TOKEN_EXPIRED_TIME);

                    var refreshToken = await _jwtService.BuildToken(user.UserName, REFRESH_TOKEN_EXPIRED_TIME);

                    return Ok(new UserTokenLogin(token, refreshToken, user));
                }
                return Unauthorized(new ErrorDetail(ErrorEnum.LoginFail));
            }

            return Unauthorized(new ErrorDetail(ErrorEnum.LoginFail));
        }
        [HttpPost("refresh-token")]
        public async Task<ActionResult<UserTokenLogin>> RefreshToken([FromBody] string refreshToken)
        {
            if (!string.IsNullOrEmpty(refreshToken))
            {
                var isValid = await _jwtService.ValidateToken(refreshToken);

                if (isValid)
                {
                    var token = await _jwtService.DecodeToken(refreshToken);

                    var username = token.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;

                    if (!string.IsNullOrEmpty(username))
                    {
                        var isExisted = await _userService.IsExistedUser(username);

                        if (isExisted)
                        {
                            var accessToken = await _jwtService.BuildToken(username, TOKEN_EXPIRED_TIME);

                            refreshToken = await _jwtService.BuildToken(username, REFRESH_TOKEN_EXPIRED_TIME);

                            return Ok(new UserTokenLogin(accessToken, refreshToken));
                        }
                    }
                }
                return Unauthorized(new ErrorDetail(ErrorEnum.ExpiredToken));
            }

            return BadRequest();
        }
    }
}
