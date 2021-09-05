using FreelanceParser.Models;
using FreelanceParser.Services.Parser;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FreelanceParser.TelegramBot.FSM.States
{
    public class ParsingVacanciesState : BaseState
    {
        public ParsingVacanciesState(TelegramStateMachine stateMachine, ITelegramBotClient client, Update data)
            : base(stateMachine, client, data) { }

        public async override Task Enter() => await _client.SendTextMessageAsync(
            _data.Message.Chat.Id, 
            "For beging parse vacancies, enter tag-search string in right format (example: c#,asp.net,symfony)");

        public async override Task Update(Update data)
        {
            _data = data;
            var vacancies = await (new VacanciesParser()).Parse(data.Message.Text);
            StringBuilder builder = new StringBuilder();
            foreach(var vacancy in vacancies)
            {
                await _client.SendTextMessageAsync(_data.Message.Chat.Id, GetVacancyString(builder, vacancy));
                builder.Clear();
            }
        }

        private string GetVacancyString(StringBuilder builder, Vacancy vacancy)
        {
            builder.AppendLine("Название:");
            builder.AppendLine(vacancy.Title);
            builder.AppendLine();

            builder.AppendLine("Описание:");
            builder.AppendLine(vacancy.Description);
            builder.AppendLine();

            builder.AppendLine("Опубликован:");
            builder.AppendLine(vacancy.TimePassed);
            builder.AppendLine();

            builder.AppendLine("Стоимость:");
            builder.AppendLine(vacancy.Cost);
            builder.AppendLine();

            builder.AppendLine("Ссылка:");
            builder.Append("https://freelance.ru/");
            builder.AppendLine(vacancy.UrlAddress);
            builder.AppendLine();

            return builder.ToString();
        }
    }
}