using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trello.Service.Models.CheckLists.Request;
using Trello.Service.Services.Interfaces;

namespace Trello.API.Controllers
{
    [Route("cards")]
    [Authorize]
    public class CardController : BaseController
    {
        private ICheckListService _checkListService;

        public CardController(ICheckListService checkListService)
        {
            _checkListService = checkListService;
        }
        [HttpPost("{cardId}/checklists")]
        public async Task<ActionResult> CreateCardCheckList([FromRoute] int cardId, [FromBody] CheckListCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                request.SetCardId(cardId);
                await _checkListService.CreateCheckListAsync(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{cardId}/checklists/{checkListId}")]
        public async Task<ActionResult> DeleteCardCheckList([FromRoute] int cardId, [FromRoute] int checkListId)
        {
            await _checkListService.DeleteCheckListAsync(checkListId);
            return Ok();
        }
    }
}
