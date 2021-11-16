using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Entities;
using Trello.Service.Models.WorkspaceUsers.Request;

namespace Trello.Service.Models.Workspaces.Request
{
    public class WorkspaceCreateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
        public List<WorkspaceUserCreateRequest> Users { get; set; } = new List<WorkspaceUserCreateRequest>();

        public Workspace ConvertToEntity(int userId)
        {
            return new Workspace()
            {
                Name = Name,
                Description = Description,
                CreatedBy = userId
            };
        }
    }
}
