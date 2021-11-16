using System.ComponentModel.DataAnnotations;
using Trello.Domain.Entities;

namespace Trello.Service.Models.Items.Request
{
    public class ItemCreateRequest
    {
        private int _checkListId;
        public int GetCheckListId() => _checkListId;
        public void SetCheckListId(int id) => _checkListId = id;

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public Item ConvertToEntity()
        {
            return new Item
            {
                CheckListId = _checkListId,
                Name = Name,
                IsCompleted = false
            };
        }

    }
}
