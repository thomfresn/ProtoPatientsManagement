using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PatientsMgmtModel;

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

            DataContext = new ExamsViewModel();
        }
    }

    public class ExamsViewModel 
    {
        public ObservableCollection<ExamViewModel> Exams { get; } = new ObservableCollection<ExamViewModel>()
        {
            new ExamViewModel("Yves Dupont", "HCC diagnosed", "06/10/2017", "Thomas Fresneau"),
            new ExamViewModel("Pierre Dupont", "Healthy patient", "06/05/2016", "Thomas Fresneau"),
            new ExamViewModel("Bob Maurane", "Cyrhose", "06/04/2017", "Pierre-Paul Jacques")
        };
    }
}
