using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Entities;
using Trello.Domain.Interfaces;
using Trello.Service.Services.Interfaces;

namespace Trello.Service.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public async Task<bool> CreateUser(User user)
        {
            UnitOfWork.UserRepository.Add(user);
            var saved = await UnitOfWork.CommitAsync();
            return saved > 0;
        }

        public Task<bool> IsExistedUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
