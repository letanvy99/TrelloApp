using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Entities;

namespace Trello.Service.Models.Lists.Response
{
    public class ListVm
    {
        public int? WorkspaceId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int? SortOrder { get; set; }

        public ListVm(List entity)
        {
            WorkspaceId = entity.WorkspaceId;
            Name = entity.Name;
            Color = entity.Color;
            SortOrder = entity.SortOrder;
        }
    }
}
