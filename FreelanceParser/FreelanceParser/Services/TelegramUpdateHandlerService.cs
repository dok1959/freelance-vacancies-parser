using FreelanceParser.TelegramBotFSM;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.Services
{
    public class TelegramUpdateHandlerService
    {
        private ITelegramBotClient _client;
        private TelegramStateMachine _stateMachine;

        public void HandleAsync(Update data)
        {
            _stateMachine.Update(data);
        }

    }
}
