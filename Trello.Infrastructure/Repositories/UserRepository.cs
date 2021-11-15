using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<bool> IsExistedUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
