using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Entities;

namespace Trello.Service.Models.CheckLists.Request
{
    public class CheckListCreateRequest
    {
        private int _cardId;
        public int GetCardId() => _cardId;
        public void SetCardId(int id) => _cardId = id;
        public string Name { get; set; }
        public int SortOrder { get; set; }

        public CheckList ConvertToEntity()
        {
            return new CheckList
            {
                CardId=_cardId,
                Name = Name,
                SortOrder = SortOrder
            };
        }
    }
}
