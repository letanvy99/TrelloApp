using System.ComponentModel.DataAnnotations;
using Trello.Domain.Entities;

namespace Trello.Service.Models.Users.Request
{
    public class UserCreateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        public User ConverToEntity()
        {
            return new User
            {
                UserName = UserName,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}
