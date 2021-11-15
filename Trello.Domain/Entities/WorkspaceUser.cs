using System;
using System.Collections.Generic;

#nullable disable

namespace Trello.Domain.Entities
{
    public partial class WorkspaceUser
    {
        public int UserId { get; set; }
        public int WorkspaceId { get; set; }

        public virtual User User { get; set; }
        public virtual Workspace Workspace { get; set; }
    }
}
