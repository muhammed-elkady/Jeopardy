using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy.Console.Services.JeopardyScraper
{
    public interface IJeopardyScraper
    {
        Task ScrapeJeopardyQuestions(int difficulty, int numberOfQuestions = 1);
    }
}
