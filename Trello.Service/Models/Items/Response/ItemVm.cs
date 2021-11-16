using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Service.Models.Items.Response
{
    public class ItemVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
