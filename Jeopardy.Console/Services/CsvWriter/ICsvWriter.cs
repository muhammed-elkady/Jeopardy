using Jeopardy.Console.Entities;

namespace Jeopardy.Console.Services.CsvWriter
{
    public interface ICsvWriter
    {
        void Write(List<JeopardyQuestion> jeopardyQuestions);
    }
}
