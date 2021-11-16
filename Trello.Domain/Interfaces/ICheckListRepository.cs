using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Entities;

namespace Trello.Domain.Interfaces
{
    public interface ICheckListRepository : IRepository<CheckList>
    {
    }
}
