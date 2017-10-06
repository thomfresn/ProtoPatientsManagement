using System.Collections.Generic;

namespace PatientsMgmtModel.CSVExport
{
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