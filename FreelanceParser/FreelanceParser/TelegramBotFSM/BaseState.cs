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
        protected Update _data;

        public BaseState(string name, TelegramStateMachine stateMachine, ITelegramBotClient client, Update data)
        {
            Name = name;
            _stateMachine = stateMachine;
            _client = client;
            _data = data;
        }

        public abstract Task Enter();

        public abstract Task Update(Update data);

        public abstract Task Exit();
    }
}
