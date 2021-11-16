using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }
        public IWorkspaceRepository WorkspaceRepository { get; }
        public IWorkspaceUserRepository WorkspaceUserRepository { get; }
        public ILabelRepository LabelRepository { get; }
        public ICardRepository CardRepository { get; }
        public ICheckListRepository CheckListRepository { get; }
        public IListRepository ListRepository { get; }
        public IItemRepository ItemRepository { get; }
        Task<int> CommitAsync();
    }
}
