using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Entities;
using Trello.Service.Models.CardLabels.Response;
using Trello.Service.Models.CardUsers.Response;
using Trello.Service.Models.CheckLists.Response;

namespace Trello.Service.Models.Cards.Response
{
    public class CardVm
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public int SortOrder { get; set; }
        public List<CardUserVm> Users { get; set; }
        public List<LabelVm> Labels { get; set; }
        public List<CheckListVm> Checklists { get; set; }

    }
}
