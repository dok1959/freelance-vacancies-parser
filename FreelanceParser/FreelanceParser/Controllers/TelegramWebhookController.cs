using FreelanceParser.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace FreelanceParser.Controllers
{
    public class TelegramWebhookController : ControllerBase
    {
        private TelegramUpdateHandlerService _updateHandlerService;
        public TelegramWebhookController(TelegramUpdateHandlerService updateHandlerService)
        {
            _updateHandlerService = updateHandlerService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Update update)
        {
            if (update == null)
                return BadRequest();

            _updateHandlerService.HandleAsync(update);

            return Ok();
        }
    }
}
