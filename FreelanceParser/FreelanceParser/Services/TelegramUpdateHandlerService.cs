using FreelanceParser.TelegramBotFSM;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.Services
{
    public class TelegramUpdateHandlerService
    {
        private ITelegramBotClient _client;
        private TelegramStateMachine _stateMachine;

        public TelegramUpdateHandlerService(ITelegramBotClient client, TelegramStateMachine stateMachine)
        {
            _client = client;
            _stateMachine = stateMachine;
        }

        public void HandleAsync(Update data)
        {
            if(!_stateMachine.IsInitialized)
                _stateMachine.Initialize(_client, data);

            _stateMachine.Update(data);
        }

    }
}
