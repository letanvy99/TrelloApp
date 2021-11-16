using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                UserId= UserId
            };
        }
    }
}
