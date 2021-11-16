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

        private IWorkspaceRepository _workspaceRepository;

        private IWorkspaceUserRepository _workspaceUserRepository;

        private ILabelRepository _labelRepository;

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

        public IWorkspaceRepository WorkspaceRepository
        {
            get { return _workspaceRepository ??= new WorkspaceRepository(_dbFactory); }
        }

        public IWorkspaceUserRepository WorkspaceUserRepository
        {
            get { return _workspaceUserRepository ??= new WorkspaceUserRepository(_dbFactory); }
        }

        public ILabelRepository LabelRepository
        {
            get { return _labelRepository ??= new LabelRepository(_dbFactory); }
        }

        public Task<int> CommitAsync()
        {
            return _dbFactory.DbContext.SaveChangesAsync();
        }
    }
}
