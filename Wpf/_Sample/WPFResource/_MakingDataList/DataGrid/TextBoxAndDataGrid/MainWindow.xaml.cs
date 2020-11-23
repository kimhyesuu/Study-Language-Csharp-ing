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

namespace TextBoxAndDataGrid
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
         this.DataContext = this;
         SelectedDog = new Dog();
      }

      public Dog SelectedDog { get; set; }


      private void DataGrid_Loaded(object sender, RoutedEventArgs e)
      {
         // ... Create.
         var items = new List<Dog>();
         items.Add(new Dog("Fido", 10));
         items.Add(new Dog("Spark", 20));
         items.Add(new Dog("Fluffy", 4));
         items.Add(new Dog("Rover", 100));
         items.Add(new Dog("Mister Mars", 30));

         // ... Assign.
         var grid = sender as DataGrid;
         grid.ItemsSource = items;
      }
   }

   class Dog
   {
      public string Name { get; set; }
      public int Size { get; set; }

      public Dog(string name, int size)
      {
         this.Name = name;
         this.Size = size;
      }

      public Dog()
      {

      }
   }
}
