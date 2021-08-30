using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBot.FSM.States
{
    public class IdleState : BaseState
    {
        public IdleState(TelegramStateMachine stateMachine, ITelegramBotClient client, Update data)
            : base(stateMachine, client, data) { }

        public override Task Update(Update data)
        {
            _data = data;
            return Task.CompletedTask;
        }
    }
}
