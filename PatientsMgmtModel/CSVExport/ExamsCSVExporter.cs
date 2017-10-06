using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace PatientsMgmtModel
{
    public static class ExamsCSVExporter
    {
        public static void ExportExams(string filePath, IEnumerable<Exam> exams)
        {
            ExamsForCSVExport examsForCsvExport = new ExamsForCSVExport(exams);
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                var csv = new CsvWriter(streamWriter);
                csv.WriteRecords(examsForCsvExport.Exams);
            }
        }
    }

    internal class ExamsForCSVExport
    {
        private readonly List<ExamForCSVExport> exportableExams = new List<ExamForCSVExport>();

        public ExamsForCSVExport(IEnumerable<Exam> exams)
        {
            foreach (Exam exam in exams)
            {
                var exportableExam = new ExamForCSVExport(exam);
                exportableExams.Add(exportableExam);
            }
        }

        public IEnumerable<ExamForCSVExport>Exams => exportableExams;


    }
}