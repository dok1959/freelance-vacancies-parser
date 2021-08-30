using BotCore.FSM;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBot.FSM.States
{
    public abstract class BaseState : IState<Update>
    {
        protected readonly TelegramStateMachine _stateMachine;
        protected readonly ITelegramBotClient _client;
        protected Update _data;

        public BaseState(TelegramStateMachine stateMachine, ITelegramBotClient client, Update data)
        {
            _stateMachine = stateMachine;
            _client = client;
            _data = data;
        }

        public virtual Task Enter() => Task.CompletedTask;

        public abstract Task Update(Update data);

        public virtual Task Exit() => Task.CompletedTask;
    }
}
