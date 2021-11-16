using Trello.Domain.Entities;

namespace Trello.Service.Models.CardUsers.Request
{
    public class CardUserCreateRequest
    {
        public int UserId { get; set; }

        public CardUser ConvertToEntity(Card card)
        {
            return new CardUser
            {
                Card = card,
                UserId = UserId
            };
        }
    }
}
