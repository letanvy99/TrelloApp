using System.Threading.Tasks;
using Trello.Domain.Interfaces;
using Trello.Service.Enums;
using Trello.Service.Exceptions;
using Trello.Service.Models.CheckLists.Request;
using Trello.Service.Models.Error;
using Trello.Service.Services.Interfaces;

namespace Trello.Service.Services
{
    public class CheckListService : BaseService, ICheckListService
    {
        public CheckListService(IUnitOfWork unitOfWork, IIdentityUser identityUser) : base(unitOfWork, identityUser)
        {
        }

        public async Task<bool> CreateCheckListAsync(CheckListCreateRequest request)
        {
            var cardEntity = await UnitOfWork.CardRepository.FindAsync(request.GetCardId());
            if (cardEntity == null) throw new BadRequestException(new ErrorDetail(ErrorEnum.NotFoundCard).ErrorCode.ToString());
            var checkListEntity = request.ConvertToEntity();
            UnitOfWork.CheckListRepository.Add(checkListEntity);
            var result = await UnitOfWork.CommitAsync();
            return result > 0;
        }

        public async Task DeleteCheckListAsync(int checkListId)
        {
            var checkListEntity = await UnitOfWork.CheckListRepository.FindAsync(checkListId);
            if (checkListEntity == null) throw new BadRequestException(new ErrorDetail(ErrorEnum.NotFoundCheckList).ErrorCode.ToString());
            UnitOfWork.CheckListRepository.Delete(checkListEntity);
            await UnitOfWork.CommitAsync();
        }
    }
}
