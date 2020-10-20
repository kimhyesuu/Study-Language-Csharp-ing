using System;
using System.Collections.Generic;
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

namespace DataTemplateExe3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var fruitList = new List<Employee>()
            {
                new Employee()
                {
                    Name = "Alex",
                    Dept = "Mechanical",
                    TelephoneNr = "xxx-xxx-xxxxx",
                    EmployeeNr = 11
                },

                new Employee()
                {
                    Name = "Mario",
                    Dept = "Electrical",
                    TelephoneNr = "xxx-xxx-xxxxx",
                    EmployeeNr = 12
                }
            };

            FruitsList.ItemsSource = fruitList;
        }
    }


    internal class Employee
    {
        public string Name { get; set; }

        public int EmployeeNr { get; set; }

        public string Dept { get; set; }

        public string TelephoneNr { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        //public Employee(string _name, int _employeeNr, string _dept, string _telephoneNr)
        //{
        //    this._name = _name;
        //    this._employeeNr = _employeeNr;
        //    this._dept = _dept;
        //    this._telephoneNr = _telephoneNr;
        //}


    }
}
