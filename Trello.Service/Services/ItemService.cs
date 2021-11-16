using System.Threading.Tasks;
using Trello.Domain.Interfaces;
using Trello.Service.Enums;
using Trello.Service.Exceptions;
using Trello.Service.Models.Error;
using Trello.Service.Models.Items.Request;
using Trello.Service.Services.Interfaces;

namespace Trello.Service.Services
{
    public class ItemService : BaseService, IItemService
    {
        public ItemService(IUnitOfWork unitOfWork, IIdentityUser identityUser) : base(unitOfWork, identityUser)
        {
        }

        public async Task<bool> CreateItemAsync(ItemCreateRequest request)
        {
            var checkListEntity = await UnitOfWork.ItemRepository.FindAsync(request.GetCheckListId());
            if (checkListEntity == null) throw new BadRequestException(new ErrorDetail(ErrorEnum.NotFoundCheckList).ErrorCode.ToString());
            var itemEntity = request.ConvertToEntity();
            UnitOfWork.ItemRepository.Add(itemEntity);
            var result = await UnitOfWork.CommitAsync();
            return result > 0;
        }

        public async Task DeleteItemAsync(int itemId)
        {
            var itemEntity = await UnitOfWork.ItemRepository.FindAsync(itemId);
            if (itemEntity == null) throw new BadRequestException(new ErrorDetail(ErrorEnum.NotFoundItem).ErrorCode.ToString());
            UnitOfWork.ItemRepository.Delete(itemEntity);
            await UnitOfWork.CommitAsync();
        }

        public async Task UpdateItemAsync(ItemUpdateRequest request)
        {
            var checkListEntity = await UnitOfWork.ItemRepository.FindAsync(request.GetCheckListId());
            if (checkListEntity == null) throw new BadRequestException(new ErrorDetail(ErrorEnum.NotFoundCheckList).ErrorCode.ToString());
            var itemEntity = await UnitOfWork.ItemRepository.FindAsync(request.GetItemId());
            if (itemEntity == null) throw new BadRequestException(new ErrorDetail(ErrorEnum.NotFoundItem).ErrorCode.ToString());
            itemEntity = request.ConvertToEntity(itemEntity);
            UnitOfWork.ItemRepository.Update(itemEntity);
            await UnitOfWork.CommitAsync();
        }
    }
}
