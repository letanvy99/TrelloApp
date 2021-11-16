using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Entities;
using Trello.Domain.Interfaces;
using Trello.Service.Models.Labels.Request;
using Trello.Service.Models.Workspaces.Request;
using Trello.Service.Services.Interfaces;

namespace Trello.Service.Services
{
    public class WorkspaceService : BaseService, IWorkspaceService
    {
        public WorkspaceService(IUnitOfWork unitOfWork, IIdentityUser identityUser) : base(unitOfWork, identityUser)
        {

        }
        public async Task<bool> CreateWorkspace(WorkspaceCreateRequest request)
        {
            var workspaceEntity = request.ConvertToEntity(User.UserId);
            UnitOfWork.WorkspaceRepository.Add(workspaceEntity);
            if (request.Users.Any())
            {
                var workspaceUserEntity = request.Users.Select(_ => _.ConverToEntity(workspaceEntity)).AsEnumerable();
                UnitOfWork.WorkspaceUserRepository.AddRange(workspaceUserEntity);
            }
            var entityLabel = ListLabelDefault(workspaceEntity);
            UnitOfWork.LabelRepository.AddRange(entityLabel);
            var result = await UnitOfWork.CommitAsync();
            return result > 0;
        }
        private IEnumerable<Label> ListLabelDefault(Workspace workspace)
        {
            var labels = new List<LabelCreateRequest>();
            labels.Add(new LabelCreateRequest(workspace, "#FF6369"));
            labels.Add(new LabelCreateRequest(workspace, "#61C76D"));
            labels.Add(new LabelCreateRequest(workspace, "#7AC5FA"));
            labels.Add(new LabelCreateRequest(workspace, "#D1458D"));
            labels.Add(new LabelCreateRequest(workspace, "#D18156"));
            var result = labels.Select(_ => _.ConvertToEntity()).AsEnumerable();
            return result;
        }
    }
}
