using Trello.Domain.Entities;
using Trello.Domain.Interfaces;

namespace Trello.Infrastructure.Repositories
{
    public class WorkspaceUserRepository : Repository<WorkspaceUser>, IWorkspaceUserRepository
    {
        public WorkspaceUserRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
