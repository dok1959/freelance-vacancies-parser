using AngleSharp;
using FreelanceParser.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FreelanceParser.Services.Parser
{
    public class VacanciesParser : IVacanciesParser
    {
        public async Task<IEnumerable<Vacancy>> Parse(string searchString)
        {
            var config = Configuration.Default.WithDefaultLoader();

            string tags = GetTagsString(searchString.Split(','));
            var address = @$"https://freelance.ru/project/search/pro?c%5B0%5D=4&q={tags}&m=or&e=&f=&t=&o=1&page=1&per-page=100";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);
            var elements = document.GetElementsByClassName("box-shadow project");
            List<Vacancy> vacancies = new List<Vacancy>();
            foreach(var element in elements)
            {
                vacancies.Add(new Vacancy
                {
                    Title = element.GetElementsByClassName("title")?.First()?.GetAttribute("title")?.Trim(),
                    Description = element.GetElementsByClassName("description")?.First()?.TextContent?.Trim(),
                    UrlAddress = element.GetElementsByClassName("description")?.First()?.GetAttribute("href")?.Trim(),
                    Cost = element.GetElementsByClassName("cost")?.First()?.TextContent?.Trim(),
                    TimePassed = element.GetElementsByClassName("timeago")?.First().TextContent?.Trim()
                });
            }
            return vacancies;
        }

        private string GetTagsString(string[] tags)
        {
            StringBuilder builder = new StringBuilder();
            foreach(var tag in tags)
            {
                builder.Append(HttpUtility.UrlEncode(tag));
                builder.Append("%2C");
            }
            return builder.ToString();
        }
    }
}
