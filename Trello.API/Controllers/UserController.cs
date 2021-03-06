using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trello.Service.Models.Users.Request;
using Trello.Service.Services.Interfaces;

namespace Trello.API.Controllers
{
    [Route("users")]
    public class UserController : BaseController
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult> CreateUser(UserCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateUser(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
