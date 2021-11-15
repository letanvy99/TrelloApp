using System;
using System.Collections.Generic;
using Trello.Domain.Base;

#nullable disable

namespace Trello.Domain.Entities
{
    public partial class Item : AuditEntity<int>
    {
        public int CheckListId { get; set; }
        public string Name { get; set; }
        public bool? IsCompleted { get; set; }

        public virtual CheckList CheckList { get; set; }
    }
}
