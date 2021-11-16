using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Service.Models.CheckLists.Request;

namespace Trello.Service.Services.Interfaces
{
    public interface ICheckListService
    {
        Task<bool> CreateCheckListAsync(CheckListCreateRequest request);
        Task DeleteCheckListAsync(int checkListId);
    }
}
