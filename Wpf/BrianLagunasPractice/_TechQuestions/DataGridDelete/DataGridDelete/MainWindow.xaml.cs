using DataGridDelete.ViewModels;
using System.Windows;

namespace DataGridDelete
{
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
         this.DataContext = new MainViewModel();
      }
   }
}
