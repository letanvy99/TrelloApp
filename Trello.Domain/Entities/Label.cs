using System;
using System.Collections.Generic;
using Trello.Domain.Base;

#nullable disable

namespace Trello.Domain.Entities
{
    public partial class Label : AuditEntity<int>
    {
        public Label()
        {
            Cards = new HashSet<Card>();
        }

        public int? WorkspaceId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public virtual Workspace Workspace { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}
