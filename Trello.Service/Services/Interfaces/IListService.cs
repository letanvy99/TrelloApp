using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Service.Models.Lists.Request;
using Trello.Service.Models.Lists.Response;

namespace Trello.Service.Services.Interfaces
{
    public interface IListService
    {
        Task<bool> CreateListAsync(ListCreateRequest request);
        Task<List<ListVm>> GetListAsync(int workspaceId);
        Task DeleteListAsync(int listId);
        Task UpdateListAsync(ListUpdateRequest request);
    }
}
