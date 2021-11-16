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
using Trello.Service.Models.CardLabels.Response;
using Trello.Service.Models.Cards.Response;
using Trello.Service.Models.CardUsers.Response;
using Trello.Service.Models.CheckLists.Response;
using Trello.Service.Models.Error;
using Trello.Service.Models.Items.Response;
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

        public async Task<int> CreateListAsync(ListCreateRequest request)
        {
            var listEntity = request.ConvertToEntity(User.UserId);
            UnitOfWork.ListRepository.Add(listEntity);
            await UnitOfWork.CommitAsync();
            return listEntity.Id;
        }
        public async Task<List<ListVm>> GetListAsync(int workspaceId)
        {
            Expression<Func<List, bool>> filter = l => l.WorkspaceId == workspaceId && l.IsDeleted == false;
            return await UnitOfWork.ListRepository.List(filter)
                            .Select(_ => new ListVm()
                            {
                                Id = _.Id,
                                WorkspaceId = _.WorkspaceId,
                                Color = _.Color,
                                Name = _.Name,
                                SortOrder = _.SortOrder,
                                Cards = _.Cards.Select(c => new CardVm()
                                {
                                    DueDate = c.DueDate,
                                    Priority = c.Priority,
                                    ImageUrl = c.ImageUrl,
                                    SortOrder = c.SortOrder,
                                    Labels = c.CardLabels.Select(_ => _.Label).Select(l => new LabelVm()
                                    {
                                        Color = l.Color,
                                        Id = l.Id,
                                        Name = l.Name
                                    }).ToList(),
                                    Name = c.Name,
                                    Users = c.CardUsers.Select(_ => _.User).Select(u => new CardUserVm() {
                                        ImageUrl = u.ImageUrl,
                                        UserId = u.Id
                                    }).ToList(),
                                    Checklists = c.CheckLists.Select(_=> new CheckListVm()
                                    {
                                        Id=_.Id,
                                        Name = _.Name,
                                        SortOrder = _.SortOrder,
                                        Items = _.Items.Select(it => new ItemVm()
                                        {
                                            Id = it.Id,
                                            Name = it.Name,
                                            IsCompleted = it.IsCompleted
                                        }).ToList()
                                    }).ToList()
                                }).ToList(),
                            }).ToListAsync();
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
