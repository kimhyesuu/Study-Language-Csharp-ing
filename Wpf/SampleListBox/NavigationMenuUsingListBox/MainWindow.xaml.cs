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

namespace NavigationMenuUsingListBox
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
         DataContext = this;
      }

      public List<ViewItem> View { get; set; } = ViewItems.GetViewItem();
   }

   public class ViewItems
   {
      public static List<ViewItem> GetViewItem()
      {
         List<ViewItem> viewList = new List<ViewItem>()
         {
            new ViewItem() { Views = "Home"},
            new ViewItem() { Views = "Email"},
            new ViewItem() { Views = "Cloud"}
         };

         return viewList;
      }
   }

   public class ViewItem
   {
      public string Views { get; set; }
      public override string ToString()
      {
         return this.Views;
      }
   }
}
