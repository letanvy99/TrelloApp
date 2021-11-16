using Trello.Domain.Entities;

namespace Trello.Service.Models.CardLabels.Request
{
    public class CardLabelCreateRequest
    {
        public int LabelId { get; set; }

        public CardLabel ConvertToEntity(Card card)
        {
            return new CardLabel
            {
                Card = card,
                LabelId = LabelId
            };
        }
    }
}
