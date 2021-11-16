using Trello.Domain.Entities;
using Trello.Domain.Interfaces;

namespace Trello.Infrastructure.Repositories
{
    public class CardUserRepository : Repository<CardUser>, ICardUserRepository
    {
        public CardUserRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
