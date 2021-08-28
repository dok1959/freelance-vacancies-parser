using FreelanceParser.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FreelanceParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramWebhookController : ControllerBase
    {
        private TelegramUpdateHandlerService _updateHandlerService;
        public TelegramWebhookController(TelegramUpdateHandlerService updateHandlerService)
        {
            _updateHandlerService = updateHandlerService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Update update)
        {
            if (update == null)
                return BadRequest();

            await _updateHandlerService.HandleAsync(update);

            return Ok();
        }
    }
}
