using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trello.Domain.Entities;
using Trello.Service.Models.Request;
using Trello.Service.Services.Interfaces;

namespace Trello.API.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult> AddUser(UserCreateRequest request)
        {
            var user = new User()
            {
                Email = request.Email,
                Birthday = DateTime.Parse(request.Birthday),
                UserName = request.UserName,
                LastName = request.LastName,
                FirstName = request.FirstName
            };
            await _userService.CreateUser(user);

            return Ok();
        }
    }
}
