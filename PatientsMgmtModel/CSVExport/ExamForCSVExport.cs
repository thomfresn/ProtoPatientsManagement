namespace PatientsMgmtModel
{
    internal class ExamForCSVExport
    {
        public ExamForCSVExport(Exam exam)
        {
            Report = exam.Report.ToString();
            PhysicianName = exam.Physician.Name;
            ExamDate = exam.Date.ToString();
            PatientName = exam.Patient.Name;
        }

        public string PatientName { get; set; }

        public string ExamDate { get; set; }
        public string PhysicianName { get; set; }

        public string Report { get; set; }
    }
}