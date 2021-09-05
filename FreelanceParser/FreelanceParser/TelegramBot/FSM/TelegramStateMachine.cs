using Bot.Core.FSM;
using FreelanceParser.TelegramBot.FSM.States;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBot.FSM
{
    public class TelegramStateMachine : StateMachine<BaseState, ITelegramBotClient, Update>
    {
        private ITelegramBotClient _client;
        public TelegramStateMachine(ITelegramBotClient client)
        {
            _client = client;
        }

        public override Task SetCurrentState(BaseState state)
        {
            _currentState?.Exit();
            if (state != null)
                _currentState = state;
            _currentState.Enter();
            return Task.CompletedTask;
        }

        public override Task Update(Update data)
        {
            if (data.Message == null)
                return Task.CompletedTask;
            switch(data.Message.Text)
            {
                case "/start": return SetCurrentState(new GreetingState(this, _client, data));
                case "/stop": return SetCurrentState(new IdleState(this, _client, data));
                case "/parse": return SetCurrentState(new ParsingVacanciesState(this, _client, data));
            }
            return _currentState.Update(data);
        }

        public override void Initialize(ITelegramBotClient client, Update data)
        {
            SetCurrentState(new IdleState(this, client, data));
            IsInitialized = true;
        }
    }
}
