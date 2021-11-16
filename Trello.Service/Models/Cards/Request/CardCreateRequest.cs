using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Trello.Domain.Entities;
using Trello.Service.Models.CardLabels.Request;
using Trello.Service.Models.CardUsers.Request;

namespace Trello.Service.Models.Cards.Request
{
    public class CardCreateRequest
    {
        private int _listId;
        public int GetListId() => _listId;
        public void SetListId(int id) => _listId = id;
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Priority { get; set; }
        public string DueDate { get; set; }
        public List<CardUserCreateRequest> Users { get; set; } = new List<CardUserCreateRequest>();
        public List<CardLabelCreateRequest> Labels { get; set; } = new List<CardLabelCreateRequest>();

        public Card ConvertToEntity()
        {
            return new Card
            {
                ListId = _listId,
                Name = Name,
                ImageUrl = ImageUrl,
                Priority = Priority,
                DueDate = DateTime.Parse(DueDate)
            };
        }
    }
}
