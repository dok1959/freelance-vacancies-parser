using FreelanceParser.TelegramBot.FSM;
using System.Threading.Tasks;
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

        public async Task Handle(Update data)
        {
            if(!_stateMachine.IsInitialized)
                _stateMachine.Initialize(_client, data);

            await _stateMachine.Update(data);
        }

    }
}
