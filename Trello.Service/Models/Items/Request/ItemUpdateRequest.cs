using System.ComponentModel.DataAnnotations;
using Trello.Domain.Entities;

namespace Trello.Service.Models.Items.Request
{
    public class ItemUpdateRequest
    {
        private int _checkListId;
        private int _itemId;
        public int GetCheckListId() => _checkListId;
        public int GetItemId() => _itemId;
        public void SetCheckListId(int id) => _checkListId = id;
        public void SetItemId(int id) => _itemId = id;

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public bool IsCompleted { get; set; }

        public Item ConvertToEntity(Item entity)
        {
            entity.Name = Name;
            entity.IsCompleted = IsCompleted;
            return entity;
        }
    }
}
