using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Trello.Domain.Entities;
using Trello.Domain.Interfaces;

namespace Trello.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
        public async Task<bool> IsExistedUserAsync(string userName)
        {
            return await DbSet.AnyAsync(_ => _.UserName == userName);
        }
        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            var user = await DbSet.Where(x => x.UserName == userName && x.IsDeleted == false).FirstOrDefaultAsync();
            return user;
        }
    }
}
