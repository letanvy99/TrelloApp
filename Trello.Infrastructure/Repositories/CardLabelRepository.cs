using Trello.Domain.Entities;
using Trello.Domain.Interfaces;

namespace Trello.Infrastructure.Repositories
{
    public class CardLabelRepository : Repository<CardLabel>, ICardLabelRepository
    {
        public CardLabelRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
