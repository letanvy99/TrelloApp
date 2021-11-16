using System.ComponentModel.DataAnnotations;
using Trello.Domain.Entities;

namespace Trello.Service.Models.Lists.Request
{
    public class ListCreateRequest
    {
        private int _workspaceId;
        public int GetWorkspaceId() => _workspaceId;
        public void SetWorkspaceId(int id) => _workspaceId = id;
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Color { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int SortOrder { get; set; }

        public List ConvertToEntity(int currentUserId)
        {
            return new List
            {
                WorkspaceId = _workspaceId,
                Name = Name,
                Color = Color,
                SortOrder = SortOrder,
                CreatedBy = currentUserId
            };
        }
    }
}
