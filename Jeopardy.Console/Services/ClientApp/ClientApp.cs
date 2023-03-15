using Jeopardy.Console.Services.JeopardyScraper;

namespace Jeopardy.Console.Services.ClientApp
{
    public class ClientApp : IClientApp
    {
        private readonly IJeopardyScraper _jeopardyScraper;

        public ClientApp(IJeopardyScraper jeopardyScraper)
        {
            _jeopardyScraper = jeopardyScraper;
        }
        public async void StartApp()
        {
            try
            {
                int difficulty = 1;
                int numberOfQuestions;
                bool difficultyInput = false;
                bool numberOfQuestionsInput = false;

                do
                {
                    System.Console.WriteLine("\n\n\n____________________");
                    System.Console.WriteLine("Welcome to Jeopardy!");
                    System.Console.WriteLine("____________________");

                    System.Console.WriteLine("\n\n\n\nPlease insert difficulty for Jeopardy questions");
                    difficultyInput = int.TryParse(System.Console.ReadLine(), out difficulty);

                    System.Console.WriteLine("Please insert the number of Jeopardy questions you want to save");
                    numberOfQuestionsInput = int.TryParse(System.Console.ReadLine(), out numberOfQuestions);


                } while (!difficultyInput || !numberOfQuestionsInput);

                await _jeopardyScraper?.ScrapeJeopardyQuestions(difficulty, numberOfQuestions);
            }
            catch (Exception e)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine(":( Sadly, an error occurred during scraping Jeopardy questions!");
                System.Console.ResetColor();
            }
        }
    }
}
