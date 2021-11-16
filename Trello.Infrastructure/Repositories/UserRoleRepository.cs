using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Entities;
using Trello.Domain.Interfaces;

namespace Trello.Infrastructure.Repositories
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
