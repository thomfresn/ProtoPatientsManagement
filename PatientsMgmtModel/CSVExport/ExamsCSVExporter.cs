using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace PatientsMgmtModel.CSVExport
{
    //Uses CSVHelper library: https://joshclose.github.io/CsvHelper/
    public class ExamsCSVExporter : IExamsExporter
    {
        public void Export(string filePath, IEnumerable<Exam> exams)
        {
            ExamsForCSVExchange examsForCsvExchange = new ExamsForCSVExchange(exams);
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                var csv = new CsvWriter(streamWriter);
                csv.WriteRecords(examsForCsvExchange.Exams);
            }
        }
    }
}