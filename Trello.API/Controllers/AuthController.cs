using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        //[HttpPost("login")]
        //[AllowAnonymous]
    }
}
