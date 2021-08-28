using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBotFSM
{
    public class Ending : BaseState
    {
        public Ending(TelegramStateMachine stateMachine, ITelegramBotClient client) 
            : base(nameof(Ending), stateMachine, client) { }

        public async override Task Enter(Update data) => await _client.SendTextMessageAsync(1, "GoodBye");

        public async override Task Update(Update data)
        {
            await _stateMachine.SetCurrentState(new Greeting(_stateMachine, _client));
        }

        public override Task Exit(Update data) => Task.CompletedTask;
    }
}
