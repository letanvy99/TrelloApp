using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trello.Service.Models.Cards.Request;
using Trello.Service.Services.Interfaces;

namespace Trello.API.Controllers
{
    [Route("lists")]
    [Authorize]
    public class ListController : BaseController
    {
        private ICardService _cardService;

        public ListController(ICardService cardService)
        {
            _cardService = cardService;
        }
        [HttpPost("{listId}/cards")]
        public async Task<ActionResult> CreateListCard([FromRoute] int listId, [FromBody] CardCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                request.SetListId(listId);
                await _cardService.CreateCardAsync(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{listId}/cards/{cardId}")]
        public async Task<ActionResult> DeleteListCard([FromRoute] int listId, [FromRoute] int cardId)
        {
            await _cardService.DeleteCardAsync(cardId);
            return Ok();
        }

    }
}
