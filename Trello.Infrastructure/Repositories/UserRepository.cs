using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Entities;
using Trello.Domain.Interfaces;

namespace Trello.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>,IUserRepository
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
        
        //public async Task<List<User>> GetUsersAsync(string userName)
        //{
        //    // Kieu the
        //    return await this.List(GetFilter()).ToListAsync();
        //}
        //public Expression<Func<User, bool>> GetFilter()
        //{
        //    return u => true;
        //}
    }
}
