namespace PatientsMgmtModel
{
    public class Report
    {
        private string report;

        public Report(string report)
        {
            this.report = report;
        }

        public override string ToString()
        {
            return this.report;
        }
    }
}