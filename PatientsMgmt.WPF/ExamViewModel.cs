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

        public string PatientName { get; }

        public string ExamDate { get; }
        public string PhysicianName { get;  }

        public string Report { get; }
    }
}