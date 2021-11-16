using System.ComponentModel.DataAnnotations;

namespace Trello.Service.Models.Users.Request
{
    public class UserLogin
    {
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
