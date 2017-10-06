﻿using PatientsMgmtModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PatientsMgmt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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
        private IEnumerable<Exam> exams;

        public ExamsViewModel(IEnumerable<Exam> exams)
        {
            this.exams = exams;
            foreach (Exam exam in exams)
            {
                Exams.Add(new ExamViewModel(exam.Patient.Name, exam.Report.ToString(), exam.Date.ToString(), exam.Physician.Name));
            }
        }

        public ObservableCollection<ExamViewModel> Exams { get; } = new ObservableCollection<ExamViewModel>();

        public ICommand ExportCSVCommand => new ExportCSVCommand(exams);
    }

    public class ExportCSVCommand : ICommand
    {
        private IEnumerable<Exam> exams;

        public ExportCSVCommand(IEnumerable<Exam> exams)
        {
            this.exams = exams;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            ExamsCSVExporter.ExportExams(@"C:\Temp\export.csv", exams);
        }

        public event EventHandler CanExecuteChanged;
    }
}
