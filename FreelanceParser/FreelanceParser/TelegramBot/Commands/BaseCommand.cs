using Bot.Core.Commands;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBot.Commands
{
    public abstract class BaseCommand : ICommand<Update, ITelegramBotClient>
    {
        public abstract string Name { get; }

        public abstract bool Contains(Update data);

        public abstract Task Execute(Update data, ITelegramBotClient client);
    }
}
