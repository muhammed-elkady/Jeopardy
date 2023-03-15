using Jeopardy.Console.Entities;
using Jeopardy.Console.Services.CsvWriter;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Jeopardy.Console.Services.JeopardyScraper
{
    public class JeopardyScraper : IJeopardyScraper
    {
        private readonly HttpClient _httpClient;
        private readonly ICsvWriter _csvWriter;

        public JeopardyScraper(
            IHttpClientFactory httpClientFactory,
            ICsvWriter csvWriter)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://jservice.io");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _csvWriter = csvWriter;
        }

        public async Task ScrapeJeopardyQuestions(int difficulty, int numberOfQuestions = 1)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.WriteLine("Scraping Jeopardy............");
            System.Console.ResetColor();
            
            var result = _httpClient.GetAsync($"/api/clues?value={difficulty}").Result;
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var questions = JsonConvert.DeserializeObject<IEnumerable<JeopardyQuestion>>(content);
                var filteredQuestions = questions?.Take(numberOfQuestions).ToList();
                _csvWriter.Write(filteredQuestions);

                System.Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Success! :)");
                System.Console.WriteLine("Scraping Jeopardy questions done successfully, you can find the csv file inside the same directory as this app.");
                System.Console.ResetColor();
            }
            else
            {
                throw new Exception("error occurred");
            }
        }
    }
}
