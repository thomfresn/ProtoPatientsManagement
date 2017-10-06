using System;

namespace PatientsMgmt
{
    public class ExamViewModel
    {
        public ExamViewModel(string patientName, string report, string examDate, string physicianName)
        {
            Report = report;
            PhysicianName = physicianName;
            ExamDate = examDate;
            PatientName = patientName;
        }

        public string PatientName { get; set; }

        public string ExamDate { get; set; }
        public string PhysicianName { get; set; }

        public string Report { get; set; }
    }
}