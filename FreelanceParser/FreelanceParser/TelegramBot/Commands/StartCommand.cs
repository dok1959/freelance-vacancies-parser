using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBot.Commands
{
    public class StartCommand : BaseCommand
    {
        public override string Name { get; }

        public override bool Contains(Update data) => data.Message.Text == Name;

        public override Task Execute(Update data, ITelegramBotClient client) => Task.CompletedTask;
    }
}
