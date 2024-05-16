using SixtyNamesAssignment.Models;
using System.Text.Json;

namespace SixtyNamesAssignment.Services
{
    /// <summary>
    /// Вмещает фукциональность для записи отчета в виде JSONю
    /// </summary>
    public static class JsonReportMaker
    {
        /// <summary>
        /// Записывает отчет о физических лицах.
        /// </summary>
        /// <param name="personCollection">Необходимые поля физических лиц для записи в отчет.</param>
        public static void MakeReport(IEnumerable<ReportModel> personCollection)
        {
            var fileName = "personsCollection.json";
            string jsonString = JsonSerializer.Serialize(personCollection);

            File.WriteAllText(fileName, jsonString);

            Console.WriteLine($"Has been written:{File.ReadAllText(fileName)}\nTo {fileName}");
        }
    }
}
