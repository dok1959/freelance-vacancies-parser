using FreelanceParser.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreelanceParser.Services.Parser
{
    interface IVacanciesParser
    {
        Task<IEnumerable<Vacancy>> Parse(string searchString);
    }
}
