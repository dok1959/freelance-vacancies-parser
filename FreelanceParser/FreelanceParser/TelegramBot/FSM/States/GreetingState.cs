using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBot.FSM.States
{
    public class GreetingState : BaseState
    {
        public GreetingState(TelegramStateMachine stateMachine, ITelegramBotClient client, Update data) 
            : base(stateMachine, client, data) { }

        public async override Task Enter() => await _client.SendTextMessageAsync(_data.Message.Chat.Id, "Greetings");

        public async override Task Update(Update data)
        {
            _data = data;
            await _stateMachine.SetCurrentState(new EndingState(_stateMachine, _client, _data));
        }
    }
}
