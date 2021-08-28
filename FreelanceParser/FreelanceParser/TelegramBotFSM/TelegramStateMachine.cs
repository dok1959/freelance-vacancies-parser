using FreelanceParser.FSM;
using FreelanceParser.TelegramBotFSM.States;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBotFSM
{
    public class TelegramStateMachine : StateMachine<BaseState, ITelegramBotClient, Update>
    {
        public override Task SetCurrentState(BaseState state)
        {
            _currentState?.Exit();
            if (state != null)
                _currentState = state;
            _currentState.Enter();
            return Task.CompletedTask;
        }

        public override Task Update(Update data) => _currentState.Update(data);

        public override void Initialize(ITelegramBotClient client, Update data)
        {
            _currentState = new Greeting(this, client, data);
            IsInitialized = true;
        }
    }
}
