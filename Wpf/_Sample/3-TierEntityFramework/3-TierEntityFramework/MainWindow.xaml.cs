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

namespace _3_TierEntityFramework
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
         // ... Create.
         var items = new List<Dog>()
         {
            new Dog { Name = "Fido", Size = 10 },
            new Dog { Name = "Spark", Size = 20},
            new Dog { Name = "Fluffy" , Size = 4},
            new Dog { Name = "Rover" , Size = 100},
            new Dog { Name = "Mister Mars", Size = 30}
         };
        
         var grid = sender as DataGrid;
         grid.ItemsSource = items;
      }
   }

   class Dog
   {
      public string Name { get; set; }
      public int Size { get; set; }      
   }
}
