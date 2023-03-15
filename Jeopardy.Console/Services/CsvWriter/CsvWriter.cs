using Jeopardy.Console.Entities;
using System.Globalization;

namespace Jeopardy.Console.Services.CsvWriter
{
    public class CsvWriter : ICsvWriter
    {
        public void Write(List<JeopardyQuestion> jeopardyQuestions)
        {
            using (var writer = new StreamWriter("../../../../Jeopardy Questions.csv"))
            using (var csv = new CsvHelper.CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<JeopardyQuestionCsvMap>();
                csv.WriteHeader<JeopardyQuestion>();
                csv.NextRecord();
                foreach (var record in jeopardyQuestions)
                {
                    csv.WriteRecord(record);
                    csv.NextRecord();
                }
            }
        }
    }
}
