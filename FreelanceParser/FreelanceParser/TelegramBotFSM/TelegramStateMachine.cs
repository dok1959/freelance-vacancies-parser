using FreelanceParser.FSM;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBotFSM
{
    public class TelegramStateMachine : StateMachine<Update>
    {
        public override Task SetCurrentState(BaseState state, Update data)
        {
            _currentState?.Exit(data);
            if (state != null)
                _currentState = state;
            _currentState.Enter(data);
            return Task.CompletedTask;
        }

        public override Task SetCurrentState(IState<Update> state, Update data)
        {
            throw new System.NotImplementedException();
        }

        public override Task Update(Update data) => _currentState.Update(data);
    }
}
