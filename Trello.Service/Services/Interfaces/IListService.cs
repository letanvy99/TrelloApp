using System.Collections.Generic;
using System.Threading.Tasks;
using Trello.Service.Models.Lists.Request;
using Trello.Service.Models.Lists.Response;

namespace Trello.Service.Services.Interfaces
{
    public interface IListService
    {
        Task<int> CreateListAsync(ListCreateRequest request);
        Task<List<ListVm>> GetListAsync(int workspaceId);
        Task DeleteListAsync(int listId);
        Task UpdateListAsync(ListUpdateRequest request);
    }
}
