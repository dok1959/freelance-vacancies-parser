using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBotFSM.States
{
    public class Ending : BaseState
    {
        public Ending(TelegramStateMachine stateMachine, ITelegramBotClient client, Update data) 
            : base(nameof(Ending), stateMachine, client, data) { }

        public async override Task Enter() => await _client.SendTextMessageAsync(_data.Message.Chat.Id, "GoodBye");

        public async override Task Update(Update data)
        {
            _data = data;
            await _stateMachine.SetCurrentState(new Greeting(_stateMachine, _client, _data));
        }

        public override Task Exit() => Task.CompletedTask;
    }
}
