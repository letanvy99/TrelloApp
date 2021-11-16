using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Interfaces;
using Trello.Infrastructure.Repositories;

namespace Trello.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbFactory _dbFactory;

        private IUserRepository _userRepository;

        private IUserRoleRepository _userRoleRepository;

        public UnitOfWork(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ??= new UserRepository(_dbFactory); }
        }

        public IUserRoleRepository UserRoleRepository
        {
            get { return _userRoleRepository ??= new UserRoleRepository(_dbFactory); }
        }

        public Task<int> CommitAsync()
        {
            return _dbFactory.DbContext.SaveChangesAsync();
        }
    }
}
