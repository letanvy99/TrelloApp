using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Trello.Domain.Entities;
using Trello.Domain.Interfaces;
using Trello.Service.Models.Users.Request;
using Trello.Service.Models.Users.Response;
using Trello.Service.Services.Interfaces;

namespace Trello.Service.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IIdentityUser identityUser) : base(unitOfWork, identityUser)
        {

        }

        public async Task<UserVm> CheckUserLogin(UserLogin userLogin)
        {
            var userEntity = await UnitOfWork.UserRepository.GetUserByUserNameAsync(userLogin.UserName);
            if (userEntity == null) return null;
            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(userEntity, userEntity.PasswordHash, userLogin.Password);
            if (result != PasswordVerificationResult.Success && result != PasswordVerificationResult.SuccessRehashNeeded)
                return null;
            return new UserVm(userEntity);
        }

        public async Task<bool> CreateUser(UserCreateRequest request)
        {
            var hasher = new PasswordHasher<User>();
            var user = request.ConverToEntity();
            user.PasswordHash = hasher.HashPassword(user, request.Password);
            UnitOfWork.UserRepository.Add(user);
            var userRole = new UserRole();
            userRole.User = user;
            userRole.RoleId = 1;
            UnitOfWork.UserRoleRepository.Add(userRole);
            var saved = await UnitOfWork.CommitAsync();
            return saved > 0;
        }

        public async Task<bool> IsExistedUser(string username)
        {
            var result = await UnitOfWork.UserRepository.IsExistedUserAsync(username);
            return result;
        }
    }
}
