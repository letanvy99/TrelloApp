using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Service.Models.Items.Response;

namespace Trello.Service.Models.CheckLists.Response
{
    public class CheckListVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public List<ItemVm> Items { get; set; }
    }
}
