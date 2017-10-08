using PatientsMgmtModel;
using PatientsMgmtModel.CSVExport;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace PatientsMgmt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ExamsViewModel(new []
            {
                new Exam(new Patient("Thomas Fresneau"), new Physician("Yves Dupont"), new Report("HCC diagnosed"), new DateTime(2017,10,16)),
                new Exam(new Patient("Thomas Fresneau"), new Physician("Pierre Dupont"), new Report("Healthy patient"), new DateTime(2014,07,4)),
                new Exam(new Patient("Pierre-Paul Jacques"), new Physician("Bob Maurane"), new Report("Cyrhose"), new DateTime(2016,06,06))
            });

        }
    }

    public class ExamsViewModel 
    {
        private readonly IEnumerable<Exam> exams;

        public ExamsViewModel(IEnumerable<Exam> exams)
        {
            this.exams = exams;
            foreach (Exam exam in this.exams)
            {
                Exams.Add(new ExamViewModel(exam.Patient.Name, exam.Report.ToString(), exam.Date.ToString(CultureInfo.CurrentCulture), exam.Physician.Name));
            }
        }

        public ObservableCollection<ExamViewModel> Exams { get; } = new ObservableCollection<ExamViewModel>();

        public ICommand ExportCSVCommand => new ExportCSVCommand(exams);
    }

    public class ExportCSVCommand : ICommand
    {
        private readonly IEnumerable<Exam> exams;

        public ExportCSVCommand(IEnumerable<Exam> exams)
        {
            this.exams = exams;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            IExamsExporter examsCSVExporter = new ExamsCSVExporter();
            examsCSVExporter.Export(@"C:\Temp\export.csv", exams);
        }

        public event EventHandler CanExecuteChanged;
    }
}
