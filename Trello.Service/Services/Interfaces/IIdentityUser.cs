using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Service.Services.Interfaces
{
    public interface IIdentityUser
    {
        int UserId { get; set; }
    }
    public class IdentityUser : IIdentityUser
    {
        public IdentityUser() { }
        public int UserId { get; set; }
    }
}
