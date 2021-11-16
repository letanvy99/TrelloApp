using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trello.Service.Models.Lists.Request;
using Trello.Service.Models.Lists.Response;
using Trello.Service.Models.Workspaces.Request;
using Trello.Service.Services.Interfaces;

namespace Trello.API.Controllers
{
    [Route("workspaces")]
    [Authorize]
    public class WorkspaceController : BaseController
    {
        private IWorkspaceService _workspaceService;
        private IListService _listService;

        public WorkspaceController(IWorkspaceService workspaceService, IListService listService)
        {
            _workspaceService = workspaceService;
            _listService = listService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateWorkspace([FromBody] WorkspaceCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                await _workspaceService.CreateWorkspace(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpPost("{workspaceId}/lists")]
        public async Task<ActionResult> CreateWorkspaceList([FromRoute] int workspaceId, [FromBody] ListCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                request.SetWorkspaceId(workspaceId);
                await _listService.CreateListAsync(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{workspaceId}/lists")]
        public async Task<ActionResult<ListVm>> GetWorkspaceList([FromRoute] int workspaceId)
        {
            var result = await _listService.GetListAsync(workspaceId);
            return Ok(result);
        }
        [HttpPut("{workspaceId}/lists/{listId}")]
        public async Task<ActionResult> PutWorkspaceList([FromRoute] int workspaceId, [FromRoute] int listId, [FromBody] ListUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                request.SetListId(listId);
                await _listService.UpdateListAsync(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{workspaceId}/lists/{listId}")]
        public async Task<ActionResult> DeleteWorkspaceList([FromRoute] int workspaceId, [FromRoute] int listId)
        {
            await _listService.DeleteListAsync(listId);
            return Ok();
        }
    }
}
