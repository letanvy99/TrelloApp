using System.Threading.Tasks;
using Trello.Domain.Entities;
using Trello.Service.Models.Users.Request;
using Trello.Service.Models.Users.Response;

namespace Trello.Service.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(UserCreateRequest user);
        Task<bool> IsExistedUser(string username);
        Task<UserVm> CheckUserLogin(UserLogin userLogin);
    }
}
