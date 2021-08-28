using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBotFSM.States
{
    public class Greeting : BaseState
    {
        public Greeting(TelegramStateMachine stateMachine, ITelegramBotClient client, Update data) 
            : base(nameof(Greeting), stateMachine, client, data) { }

        public async override Task Enter() => await _client.SendTextMessageAsync(_data.Message.Chat.Id, "Greetings");

        public async override Task Update(Update data)
        {
            _data = data;
            await _stateMachine.SetCurrentState(new Ending(_stateMachine, _client, _data));
        }

        public override Task Exit() { return Task.CompletedTask; }
    }
}
