using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace PatientsMgmtModel
{
    public static class ExamsCSVExporter
    {
        public static void ExportExams(string filePath, IEnumerable<Exam> exams)
        {
            ExamsForCSVExchange examsForCsvExchange = new ExamsForCSVExchange(exams);
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                var csv = new CsvWriter(streamWriter);
                csv.WriteRecords(examsForCsvExchange.Exams);
            }
        }
    }

    internal class ExamsForCSVExchange
    {
        private readonly List<ExamForCSVExchange> exportableExams = new List<ExamForCSVExchange>();

        public ExamsForCSVExchange(IEnumerable<Exam> exams)
        {
            foreach (Exam exam in exams)
            {
                var exportableExam = new ExamForCSVExchange(exam);
                exportableExams.Add(exportableExam);
            }
        }

        public IEnumerable<ExamForCSVExchange>Exams => exportableExams;


    }
}