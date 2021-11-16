using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trello.Service.Models.Items.Request;
using Trello.Service.Services.Interfaces;

namespace Trello.API.Controllers
{
    [Route("checklists")]
    [Authorize]
    public class CheckListController : BaseController
    {
        private IItemService _itemService;

        public CheckListController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpPost("{checkListId}/items")]
        public async Task<ActionResult> CreateCheckListItem([FromRoute] int checkListId, [FromBody] ItemCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                request.SetCheckListId(checkListId);
                await _itemService.CreateItemAsync(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{checkListId}/items/{itemId}")]
        public async Task<ActionResult> PutCheckListItem([FromRoute] int checkListId, [FromRoute] int itemId, [FromBody] ItemUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                request.SetCheckListId(checkListId);
                request.SetItemId(itemId);
                await _itemService.UpdateItemAsync(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{checkListId}/items/{itemId}")]
        public async Task<ActionResult> DeleteCheckListItem([FromRoute] int checkListId, [FromRoute] int itemId)
        {
            await _itemService.DeleteItemAsync(itemId);
            return Ok();
        }
    }
}