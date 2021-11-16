using System;
using Trello.Domain.Entities;

namespace Trello.Service.Models.Users.Response
{
    public class UserVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }

        public UserVm(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            PasswordHash = user.PasswordHash;
            FirstName = user.FirstName;
            LastName = user.LastName;
            ImageUrl = user.ImageUrl;
            Birthday = user.Birthday;
            Gender = user.Gender;
        }
    }
}
