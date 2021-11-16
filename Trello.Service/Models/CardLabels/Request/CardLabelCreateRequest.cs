using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
