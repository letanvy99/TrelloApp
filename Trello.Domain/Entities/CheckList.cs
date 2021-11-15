using System;
using System.Collections.Generic;
using Trello.Domain.Base;

#nullable disable

namespace Trello.Domain.Entities
{
    public partial class CheckList : AuditEntity<int>
    {
        public CheckList()
        {
            Items = new HashSet<Item>();
        }

        public int? CardId { get; set; }
        public string Name { get; set; }

        public virtual Card Card { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
