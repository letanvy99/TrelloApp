using Trello.Domain.Entities;

namespace Trello.Service.Models.WorkspaceUsers.Request
{
    public class WorkspaceUserCreateRequest
    {
        public int UserId { get; set; }

        public WorkspaceUser ConverToEntity(Workspace workspace)
        {
            return new WorkspaceUser
            {
                UserId = UserId,
                Workspace = workspace
            };
        }
    }
}
