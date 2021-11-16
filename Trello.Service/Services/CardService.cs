using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Interfaces;
using Trello.Service.Services.Interfaces;

namespace Trello.Service.Services
{
    public class CardService : BaseService, ICardService
    {
        public CardService(IUnitOfWork unitOfWork, IIdentityUser identityUser) : base(unitOfWork, identityUser)
        {

        }
    }
}
