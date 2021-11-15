using System;
using System.Collections.Generic;
using Trello.Domain.Base;

#nullable disable

namespace Trello.Domain.Entities
{
    public partial class Card : AuditEntity<int>
    {
        public Card()
        {
            CardUsers = new HashSet<CardUser>();
            CheckLists = new HashSet<CheckList>();
        }

        public int ListId { get; set; }
        public int? LabelId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Priority { get; set; }
        public DateTime? DueDate { get; set; }

        public virtual Label Label { get; set; }
        public virtual List List { get; set; }
        public virtual ICollection<CardUser> CardUsers { get; set; }
        public virtual ICollection<CheckList> CheckLists { get; set; }
    }
}
