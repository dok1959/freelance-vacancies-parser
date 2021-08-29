using FreelanceParser.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace FreelanceParser.Controllers
{
    public class TelegramWebhookController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromServices] TelegramUpdateHandlerService updateHandlerService,[FromBody] Update update)
        {
            if (update == null)
                return BadRequest();

            updateHandlerService.Handle(update);

            return Ok();
        }
    }
}
