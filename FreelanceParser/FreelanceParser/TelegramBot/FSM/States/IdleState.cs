using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBot.FSM.States
{
    public class IdleState : BaseState
    {
        public IdleState(TelegramStateMachine stateMachine, ITelegramBotClient client, Update data)
            : base(nameof(EndingState), stateMachine, client, data) { }

        public override Task Enter() => Task.CompletedTask;

        public override Task Update(Update data)
        {
            _data = data;
            return Task.CompletedTask;
        }

        public override Task Exit() => Task.CompletedTask;
    }
}
