using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Entities;

namespace Trello.Service.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(User user);
        Task<bool> IsExistedUser(string username);
    }
}
