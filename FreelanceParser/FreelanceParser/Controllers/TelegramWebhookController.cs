using FreelanceParser.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FreelanceParser.Controllers
{
    public class TelegramWebhookController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] TelegramUpdateHandlerService updateHandlerService,[FromBody] Update update)
        {
            if (update == null)
                return BadRequest();

            await updateHandlerService.Handle(update);

            return Ok();
        }
    }
}
