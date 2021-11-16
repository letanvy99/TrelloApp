using Trello.Domain.Entities;
using Trello.Domain.Interfaces;

namespace Trello.Infrastructure.Repositories
{
    public class ListRepository : Repository<List>, IListRepository
    {
        public ListRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
