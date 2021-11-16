using System.ComponentModel.DataAnnotations;
using Trello.Domain.Entities;

namespace Trello.Service.Models.Lists.Request
{
    public class ListUpdateRequest
    {
        private int _listId;
        public int GetListId() => _listId;
        public void SetListId(int id) => _listId = id;
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Color { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int SortOrder { get; set; }
        public List ConvertToEntity(List entity)
        {
            entity.Name = Name;
            entity.Color = Color;
            entity.SortOrder = SortOrder;
            return entity;
        }
    }
}
