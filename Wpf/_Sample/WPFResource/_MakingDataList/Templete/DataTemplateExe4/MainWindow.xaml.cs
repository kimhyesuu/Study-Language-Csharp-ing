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

namespace DataTemplateExe4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Task> _tasks;

        public MainWindow()
        {
            InitializeComponent();
            _tasks = new ObservableCollection<Task>()
            {
                new Task{ TaskName = "KIM1", Description = "hye2", Priority="su1"},
                new Task{ TaskName = "KIM1", Description = "hye2", Priority="su1"},
                new Task{ TaskName = "KIM1", Description = "hye2", Priority="su1"},
                new Task{ TaskName = "KIM1", Description = "hye2", Priority="su1"},
                new Task{ TaskName = "KIM1", Description = "hye2", Priority="su1"}
            };

            myList.ItemsSource = _tasks;
        } 
    }
   
    public class Task
    {

        public string TaskName { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }

        public Task()
        {

        }

        public override string ToString()
        {
            return $"{TaskName}는 {Priority}의 임무를 갖고 {Description}한다";
        }
    }
}
