using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBotFSM
{
    public class Greeting : BaseState
    {
        public Greeting(TelegramStateMachine stateMachine, ITelegramBotClient client) 
            : base(nameof(Greeting), stateMachine, client) { }

        public async override Task Enter(Update data) => await _client.SendTextMessageAsync(1, "Greetings");

        public async override Task Update(Update data)
        {
            await _stateMachine.SetCurrentState(new Ending(_stateMachine, _client));
        }

        public override Task Exit(Update data) { return Task.CompletedTask; }
    }
}
