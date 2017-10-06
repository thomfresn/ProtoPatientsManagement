using System.Collections.Generic;

namespace PatientsMgmtModel
{
    public static class ExamsCSVExporter
    {
        public static void ExportExams(string filePath, IEnumerable<Exam> exams)
        {
            ExamsForCSVExport examsForCsvExport = new ExamsForCSVExport(exams);

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


    }
}