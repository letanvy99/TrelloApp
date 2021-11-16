using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Service.Models.Cards.Request;

namespace Trello.Service.Services.Interfaces
{
    public interface ICardService
    {
        Task<bool> CreateCardAsync(CardCreateRequest request);
        Task DeleteCardAsync(int cardId);
    }
}
