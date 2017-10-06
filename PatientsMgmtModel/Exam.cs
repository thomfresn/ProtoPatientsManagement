using System;

namespace PatientsMgmtModel
{
    public class Exam
    {
        public Exam(Patient patient, Physician physician, Report report, DateTime date)
        {
            Report = report;
            Physician = physician;
            Date = date;
            Patient = patient;
        }

        public Report Report { get; }
        public Physician Physician { get;  }
        public DateTime Date { get; }
        public Patient Patient { get; }
    }
}