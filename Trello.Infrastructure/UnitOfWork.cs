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

        private ICardRepository _cardRepository;

        private ICheckListRepository _checkListRepository;

        private IListRepository _listRepository;

        private IItemRepository _itemRepository;

        public ICardUserRepository _cardUserRepository;

        public ICardLabelRepository _cardLabelRepository;

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

        public ICardRepository CardRepository
        {
            get { return _cardRepository ??= new CardRepository(_dbFactory); }
        }

        public ICheckListRepository CheckListRepository
        {
            get { return _checkListRepository ??= new CheckListRepository(_dbFactory); }
        }

        public IListRepository ListRepository
        {
            get { return _listRepository ??= new ListRepository(_dbFactory); }
        }

        public IItemRepository ItemRepository
        {
            get { return _itemRepository ??= new ItemRepository(_dbFactory); }
        }

        public ICardUserRepository CardUserRepository
        {
            get { return _cardUserRepository ??= new CardUserRepository(_dbFactory); }
        }

        public ICardLabelRepository CardLabelRepository
        {
            get { return _cardLabelRepository ??= new CardLabelRepository(_dbFactory); }
        }

        public Task<int> CommitAsync()
        {
            return _dbFactory.DbContext.SaveChangesAsync();
        }
    }
}
