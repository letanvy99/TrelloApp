using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trello.Service.Models.Workspaces.Request;
using Trello.Service.Services.Interfaces;

namespace Trello.API.Controllers
{
    [Authorize]
    public class WorkspaceController : BaseController
    {
        private IWorkspaceService _workspaceService;
        public WorkspaceController(IWorkspaceService workspaceService)
        {
            _workspaceService = workspaceService;
        }
        [HttpPost]
        public async Task<ActionResult> CreateWorkspace(WorkspaceCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                await _workspaceService.CreateWorkspace(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
