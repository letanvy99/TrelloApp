using System.Collections.Generic;
using Trello.Domain.Entities;
using Trello.Service.Models.Cards.Response;

namespace Trello.Service.Models.Lists.Response
{
    public class ListVm
    {
        public int Id { get; set; }
        public int? WorkspaceId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int? SortOrder { get; set; }
        public List<CardVm> Cards { get; set; }
    }
}
