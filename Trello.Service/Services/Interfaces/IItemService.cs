using System.Threading.Tasks;
using Trello.Service.Models.Items.Request;

namespace Trello.Service.Services.Interfaces
{
    public interface IItemService
    {
        Task<bool> CreateItemAsync(ItemCreateRequest request);
        Task DeleteItemAsync(int itemId);
        Task UpdateItemAsync(ItemUpdateRequest request);
    }
}
