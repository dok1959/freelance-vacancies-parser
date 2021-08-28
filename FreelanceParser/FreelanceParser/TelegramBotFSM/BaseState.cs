using FreelanceParser.FSM;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBotFSM
{
    public abstract class BaseState : IState<Update>
    {
        public string Name { get; }
        protected TelegramStateMachine _stateMachine;
        protected ITelegramBotClient _client;

        public BaseState(string name, TelegramStateMachine stateMachine, ITelegramBotClient client)
        {
            Name = name;
            _stateMachine = stateMachine;
            _client = client;
        }

        public abstract Task Enter(Update data);

        public abstract Task Update(Update data);

        public abstract Task Exit(Update data);
    }
}
