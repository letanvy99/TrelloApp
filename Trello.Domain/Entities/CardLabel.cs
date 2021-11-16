using System;
using System.Collections.Generic;

#nullable disable

namespace Trello.Domain.Entities
{
    public partial class CardLabel
    {
        public int CardId { get; set; }
        public int LabelId { get; set; }

        public virtual Card Card { get; set; }
        public virtual Label Label { get; set; }
    }
}
