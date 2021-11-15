using System;
using System.Collections.Generic;

#nullable disable

namespace Trello.Domain.Entities
{
    public partial class CardUser
    {
        public int CardId { get; set; }
        public int UserId { get; set; }

        public virtual Card Card { get; set; }
        public virtual User User { get; set; }
    }
}
