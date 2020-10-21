using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DataGridExe8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Patient> _list;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            // ... Get data.
            var patients = new List<Patient>();
            using (StreamReader reader = new StreamReader("C:\\Users\\juid0\\OneDrive\\바탕 화면\\ProjectManagement\\Test\\Csharpsyntax\\Wpf\\_Project\\Design\\List\\data.txt"))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line is null)
                    {
                        break;
                    }
                    patients.Add(new Patient(line));
                }
            }
            // ... Set field.
            this._list = patients;

            // ... Use ItemsSource.
            var grid = sender as DataGrid;
            grid.ItemsSource = patients;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            // ... Write the DataGrid at Closing.
            using (StreamWriter writer = new StreamWriter("data.txt"))
            {
                foreach (Patient patient in this._list)
                {
                    writer.WriteLine(patient.GetLine());
                }
            }
        }
    }

    class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public int Insurance { get; set; }
        public Patient(string line)
        {
            string[] parts = line.Split(',');
            this.FirstName = parts[0];
            this.LastName = parts[1];
            this.Code = parts[2];
            this.Insurance = int.Parse(parts[3]);
        }
        public string GetLine()
        {
            return this.FirstName + "," + this.LastName + "," + this.Code + "," +
                this.Insurance.ToString();
        }
    }
}
