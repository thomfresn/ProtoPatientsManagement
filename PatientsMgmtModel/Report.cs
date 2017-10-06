namespace PatientsMgmtModel
{
    public class Report
    {
        private readonly string report;

        public Report(string report) => this.report = report;

        public override string ToString() => report;
    }
}