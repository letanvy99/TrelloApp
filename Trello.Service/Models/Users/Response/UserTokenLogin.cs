using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Entities;

namespace Trello.Service.Models.Users.Response
{
    public class UserTokenLogin
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public UserVm User { get; set; }

        public UserTokenLogin(string accessToken, string refreshToken, UserVm user)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            User = user;
        }
        public UserTokenLogin(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
