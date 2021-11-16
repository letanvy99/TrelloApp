using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Entities;

namespace Trello.Service.Models.CardUsers.Response
{
    public class CardUserVm
    {
        public int UserId { get; set; }
        public string ImageUrl { get; set; }
    }
}
