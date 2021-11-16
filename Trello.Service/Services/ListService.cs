using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Trello.Domain.Entities;
using Trello.Domain.Interfaces;
using Trello.Service.Enums;
using Trello.Service.Exceptions;
using Trello.Service.Models.Error;
using Trello.Service.Models.Lists.Request;
using Trello.Service.Models.Lists.Response;
using Trello.Service.Services.Interfaces;

namespace Trello.Service.Services
{
    public class ListService : BaseService, IListService
    {
        public ListService(IUnitOfWork unitOfWork, IIdentityUser identityUser) : base(unitOfWork, identityUser)
        {

        }

        public async Task<bool> CreateListAsync(ListCreateRequest request)
        {
            var listEntity = request.ConvertToEntity(User.UserId);
            UnitOfWork.ListRepository.Add(listEntity);
            var result = await UnitOfWork.CommitAsync();
            return result > 0;
        }
        public async Task<List<ListVm>> GetListAsync(int workspaceId)
        {
            var listEntity = UnitOfWork.ListRepository.List(GetFilter(workspaceId));
            var result = await listEntity.Select(x => new ListVm(x)).ToListAsync();
            return result;
        }
        private Expression<Func<List, bool>> GetFilter(int workspaceId)
        {
            return u => u.WorkspaceId == workspaceId && u.IsDeleted == false;
        }
        public async Task DeleteListAsync(int listId)
        {
            var listEntity = await UnitOfWork.ListRepository.FindAsync(listId);
            if (listEntity == null) throw new BadRequestException(new ErrorDetail(ErrorEnum.NotFoundList).ErrorCode.ToString());
            UnitOfWork.ListRepository.Delete(listEntity);
            await UnitOfWork.CommitAsync();
        }
        public async Task UpdateListAsync(ListUpdateRequest request)
        {
            var listEntity = await UnitOfWork.ListRepository.FindAsync(request.GetListId());
            if (listEntity == null) throw new BadRequestException(new ErrorDetail(ErrorEnum.NotFoundList).ErrorCode.ToString());
            listEntity = request.ConvertToEntity(listEntity);
            UnitOfWork.ListRepository.Update(listEntity);
            await UnitOfWork.CommitAsync();
        }

    }
}
