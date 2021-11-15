using System;
using System.Collections.Generic;
using Trello.Domain.Base;

#nullable disable

namespace Trello.Domain.Entities
{
    public partial class Workspace : AuditEntity<int>
    {
        public Workspace()
        {
            Labels = new HashSet<Label>();
            Lists = new HashSet<List>();
            WorkspaceUsers = new HashSet<WorkspaceUser>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Label> Labels { get; set; }
        public virtual ICollection<List> Lists { get; set; }
        public virtual ICollection<WorkspaceUser> WorkspaceUsers { get; set; }
    }
}
