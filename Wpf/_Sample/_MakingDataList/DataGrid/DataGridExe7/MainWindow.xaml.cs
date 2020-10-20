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

namespace DataGridExe7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            // ... Create Orders.
            var items = new List<Order>();
            for (int i = 0; i < 100; i++)
            {
                items.Add(new Order { Size = i });
            }

            // ... Use ItemsSource.
            var grid = sender as DataGrid;
            grid.ItemsSource = items;

            // ... Scroll into view.
            grid.ScrollIntoView(items[items.Count - 1]);
        }

        private void DataGrid_CellEditEnding(object sender,
           DataGridCellEditEndingEventArgs e)
        {
            // ... Get the TextBox that was edited.
            var element = e.EditingElement as TextBox;
            var text = element.Text;

            // ... See if the text edit should be canceled.
            //     We cancel if the user typed a question mark.
            if (text == "?")
            {
                // ... Cancel the edit.
                this.Title = "Invalid";
                e.Cancel = true;
            }
            else
            {
                // ... Show the cell value in the title.
                this.Title = "You typed: " + text;
            }
        }

    }

    class Order
    {
        public int Size { get; set; }
    }
}
