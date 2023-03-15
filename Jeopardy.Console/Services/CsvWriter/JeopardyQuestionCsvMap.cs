using CsvHelper.Configuration;
using Jeopardy.Console.Entities;


namespace Jeopardy.Console.Services.CsvWriter
{
    public class JeopardyQuestionCsvMap : ClassMap<JeopardyQuestion>
    {
        public JeopardyQuestionCsvMap()
        {
            Map(m => m.Id).Index(0).Name("Id");
            Map(m => m.Value).Index(1).Name("Difficulty");
            Map(m => m.Category.Title).Index(2).Name("Category");
            Map(m => m.Question).Index(3).Name("Question");
            Map(m => m.Answer).Index(4).Name("Answer");
        }
    }
}
