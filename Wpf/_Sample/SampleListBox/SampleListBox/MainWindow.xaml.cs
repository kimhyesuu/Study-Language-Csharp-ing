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

namespace SampleListBox
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private readonly string[] arr = { "Horse", "Orion", "Fish", "Can", "MAC", "Delegate"};

      public MainWindow()
      {
         InitializeComponent();
         DataContext = this;
         bindListBox();

      }

      public List<TodoItem> ITEMLIST { get; set; } = TodoItems.GetTodoItems();

      private void bindListBox()
      {
         myListBox.ItemsSource = arr;
      }

      private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         MessageBox.Show(myListBox.SelectedItem.ToString(),"arr",MessageBoxButton.OK,MessageBoxImage.Information);
      }

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         firstLsitBox.Items.Add(TBX1.Text);
      }

      private void Button_Click_1(object sender, RoutedEventArgs e)
      {
         firstLsitBox.Items.Remove(firstLsitBox.SelectedItem);
      }
   }

   public class TodoItems
   {
      public static List<TodoItem> GetTodoItems()
      {
         var list = new List<TodoItem>();

         list.Add(new TodoItem() { Name = "KIM", Age = 19 });
         list.Add(new TodoItem() { Name = "KIM1", Age = 29 });
         list.Add(new TodoItem() { Name = "KIM2", Age = 39 });
         list.Add(new TodoItem() { Name = "KIM3", Age = 49 });

         return list;
        
      }
   }

   public class TodoItem
   {
      public string Name { get; set; }
      public int Age { get; set; }
      public override string ToString()
      {
         return this.Name;
      }
   }
}
