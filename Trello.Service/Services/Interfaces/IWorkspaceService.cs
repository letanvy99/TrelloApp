using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Service.Models.Workspaces.Request;

namespace Trello.Service.Services.Interfaces
{
    public interface IWorkspaceService
    {
        Task<bool> CreateWorkspace(WorkspaceCreateRequest request);
    }
}
