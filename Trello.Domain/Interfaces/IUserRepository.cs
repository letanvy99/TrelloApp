using System.Threading.Tasks;
using Trello.Domain.Entities;

namespace Trello.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> IsExistedUserAsync(string userName);
        Task<User> GetUserByUserNameAsync(string userName);
    }
}
