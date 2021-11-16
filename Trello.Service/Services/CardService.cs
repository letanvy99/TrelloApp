using System.Linq;
using System.Threading.Tasks;
using Trello.Domain.Interfaces;
using Trello.Service.Enums;
using Trello.Service.Exceptions;
using Trello.Service.Models.Cards.Request;
using Trello.Service.Models.Error;
using Trello.Service.Services.Interfaces;

namespace Trello.Service.Services
{
    public class CardService : BaseService, ICardService
    {
        public CardService(IUnitOfWork unitOfWork, IIdentityUser identityUser) : base(unitOfWork, identityUser)
        {
        }

        public async Task<bool> CreateCardAsync(CardCreateRequest request)
        {
            var cardEntity = request.ConvertToEntity();
            UnitOfWork.CardRepository.Add(cardEntity);
            if (request.Users.Any())
            {
                var cardUserEntity = request.Users.Select(_ => _.ConvertToEntity(cardEntity));
                UnitOfWork.CardUserRepository.AddRange(cardUserEntity);
            }
            if (request.Labels.Any())
            {
                var cardLabelEntity = request.Labels.Select(_ => _.ConvertToEntity(cardEntity));
                UnitOfWork.CardLabelRepository.AddRange(cardLabelEntity);
            }
            var result = await UnitOfWork.CommitAsync();
            return result > 0;
        }
        public async Task DeleteCardAsync(int cardId)
        {
            var cardEntity = await UnitOfWork.CardRepository.FindAsync(cardId);
            if (cardEntity == null) throw new BadRequestException(new ErrorDetail(ErrorEnum.NotFoundCard).ErrorCode.ToString());
            UnitOfWork.CardRepository.Delete(cardEntity);
            await UnitOfWork.CommitAsync();
        }
    }
}
