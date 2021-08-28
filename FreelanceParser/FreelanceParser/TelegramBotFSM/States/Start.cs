using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBotFSM.States
{
    public class Start : BaseState
    {
        public Start(TelegramStateMachine stateMachine, ITelegramBotClient client, Update data)
            : base(nameof(Start), stateMachine, client, data) { }

        public override Task Enter() => Task.CompletedTask;

        public override Task Update(Update data)
        {
            _data = data;
            _stateMachine.SetCurrentState(new Greeting(_stateMachine, _client, _data));
            return Task.CompletedTask;
        }

        public override Task Exit() => Task.CompletedTask;
    }
}
